using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class AdministradorRepository : BaseDatos, IDBRepository<Administrador>
    {
        public AdministradorRepository()
        {
        }

        public List<Administrador> Consultar()
        {
            List<Administrador> lista = new List<Administrador>();
            string sentencia = "SELECT * FROM users WHERE tipo = 'admin'";
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
            string sentencia = "DELETE FROM users WHERE id_user = @id AND tipo = 'admin'";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                AbrirConexion();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return "Se eliminó correctamente";
                }
                return "No se pudo eliminar";
            }
            finally
            {
                CerrarConexion();
            }
        }

        public string Guardar(Administrador entity)
        {
            string sentencia = "INSERT INTO users (username, password, tipo, first_name, last_name, phone_number, email) VALUES (@username, @password, 'admin', @firstName, @lastName, @phoneNumber, @email)";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@username", entity.Usuario);
            cmd.Parameters.AddWithValue("@password", entity.Contrasena);
            cmd.Parameters.AddWithValue("@firstName", entity.Nombre);
            cmd.Parameters.AddWithValue("@lastName", entity.Apellido);
            cmd.Parameters.AddWithValue("@phoneNumber", entity.Telefono);
            cmd.Parameters.AddWithValue("@email", entity.Correo);

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

        public Administrador Mappear(SqlDataReader reader)
        {
            Administrador administrador = new Administrador();
            administrador.Id = (int)reader["id_user"];
            administrador.Usuario = (string)reader["username"];
            administrador.Contrasena = Convert.ToInt32(reader["password"]);
            administrador.Nombre = (string)reader["first_name"];
            administrador.Apellido = (string)reader["last_name"];
            administrador.Telefono = Convert.ToUInt32(reader["phone_number"]);
            administrador.Correo = (string)reader["email"];
            return administrador;
        }

        public string Modificar(Administrador entity)
        {
            string sentencia = "UPDATE users SET username = @username, password = @password, first_name = @firstName, last_name = @lastName, phone_number = @phoneNumber, email = @email WHERE id_user = @id AND tipo = 'admin'";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@username", entity.Usuario);
            cmd.Parameters.AddWithValue("@password", entity.Contrasena);
            cmd.Parameters.AddWithValue("@firstName", entity.Nombre);
            cmd.Parameters.AddWithValue("@lastName", entity.Apellido);
            cmd.Parameters.AddWithValue("@phoneNumber", entity.Telefono);
            cmd.Parameters.AddWithValue("@email", entity.Correo);
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
