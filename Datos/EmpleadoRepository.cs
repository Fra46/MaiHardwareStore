using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class EmpleadoRepository : BaseDatos, IDBRepository<Empleado>
    {
        public EmpleadoRepository()
        {
        }

        public List<Empleado> Consultar()
        {
            List<Empleado> lista = new List<Empleado>();
            string sentencia = "SELECT * FROM users";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);
            try
            {
                AbrirConexion();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(Mappear(reader));
                }
                return lista;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public string Eliminar(int id)
        {
            string sentencia = "DELETE FROM users WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                AbrirConexion();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return "Se borro correctamente";
                }
                return "Negativo, no se borro";
            }
            finally
            {
                CerrarConexion();
            }
        }

        public string Guardar(Empleado entity)
        {
            string sentencia = "INSERT INTO users (username, password, tipo, first_name, last_name, phone_number, email, post, salary) " +
                              "VALUES (@username, @password, @tipo, @firstName, @lastName, @phoneNumber, @email, @post, @salary)";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@username", entity.Usuario);
            cmd.Parameters.AddWithValue("@password", entity.Contrasena);
            cmd.Parameters.AddWithValue("@tipo", entity.Tipo);
            cmd.Parameters.AddWithValue("@firstName", entity.Nombre);
            cmd.Parameters.AddWithValue("@lastName", entity.Apellido);
            cmd.Parameters.AddWithValue("@phoneNumber", entity.Telefono);
            cmd.Parameters.AddWithValue("@email", entity.Correo);
            cmd.Parameters.AddWithValue("@post", entity.Cargo);
            cmd.Parameters.AddWithValue("@salary", entity.Sueldo);

            try
            {
                AbrirConexion();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return "Se guardó correctamente";
                }
                return "No se pudo guardar";
            }
            finally
            {
                CerrarConexion();
            }
        }

        public Empleado Mappear(SqlDataReader reader)
        {
            Empleado empleado = new Empleado();
            empleado.Id = (int)reader["id_user"];
            empleado.Usuario = (string)reader["username"];
            empleado.Contrasena = (int)reader["password"];
            // Si password es string, cambia el tipo en la entidad
            // empleado.Contrasena = (string)reader["password"];
            empleado.Tipo = (string)reader["tipo"];
            empleado.Nombre = (string)reader["first_name"];
            empleado.Apellido = (string)reader["last_name"];
            empleado.Telefono = Convert.ToUInt32(reader["phone_number"]);
            empleado.Correo = (string)reader["email"];
            empleado.Cargo = (string)reader["post"];
            empleado.Sueldo = Convert.ToDouble(reader["salary"]);
            return empleado;
        }

        public string Modificar(Empleado entity)
        {
            string sentencia = "UPDATE users SET username = @username, password = @password, tipo = @tipo, first_name = @firstName, last_name = @lastName, phone_number = @phoneNumber, email = @email, post = @post, salary = @salary WHERE id_user = @id";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@username", entity.Usuario);
            cmd.Parameters.AddWithValue("@password", entity.Contrasena);
            cmd.Parameters.AddWithValue("@tipo", entity.Tipo);
            cmd.Parameters.AddWithValue("@firstName", entity.Nombre);
            cmd.Parameters.AddWithValue("@lastName", entity.Apellido);
            cmd.Parameters.AddWithValue("@phoneNumber", entity.Telefono);
            cmd.Parameters.AddWithValue("@email", entity.Correo);
            cmd.Parameters.AddWithValue("@post", entity.Cargo);
            cmd.Parameters.AddWithValue("@salary", entity.Sueldo);
            cmd.Parameters.AddWithValue("@id", entity.Id);

            try
            {
                AbrirConexion();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return "Se modificó correctamente";
                }
                return "No se pudo modificar";
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}
