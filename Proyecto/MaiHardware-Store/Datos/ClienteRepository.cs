using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class ClienteRepository : BaseDatos, IDBRepository<Cliente>
    {
        public ClienteRepository()
        {
        }

        public List<Cliente> Consultar()
        {
            List<Cliente> lista = new List<Cliente>();
            string sentencia = "SELECT * FROM clients";
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
            string sentencia = "DELETE FROM clients WHERE id_client = @id";
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

        public string Guardar(Cliente entity)
        {
            string sentencia = "INSERT INTO clients (first_name, last_name, phone_number, email, registration_date, status) VALUES (@firstName, @lastName, @phoneNumber, @email, @registrationDate, @status)";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@firstName", entity.Nombre);
            cmd.Parameters.AddWithValue("@lastName", entity.Apellido);
            cmd.Parameters.AddWithValue("@phoneNumber", entity.Telefono);
            cmd.Parameters.AddWithValue("@email", entity.Correo);
            cmd.Parameters.AddWithValue("@registrationDate", entity.FechaRegistro);
            cmd.Parameters.AddWithValue("@status", entity.Estado);

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

        public Cliente Mappear(SqlDataReader reader)
        {
            Cliente cliente = new Cliente();
            cliente.Id = (int)reader["id_client"];
            cliente.Nombre = (string)reader["first_name"];
            cliente.Apellido = (string)reader["last_name"];
            cliente.Telefono = Convert.ToUInt32(reader["phone_number"]);
            cliente.Correo = (string)reader["email"];
            cliente.FechaRegistro = (DateTime)reader["registration_date"];
            cliente.Estado = (string)reader["status"];
            return cliente;
        }

        public string Modificar(Cliente entity)
        {
            string sentencia = "UPDATE clients SET first_name = @firstName, last_name = @lastName, phone_number = @phoneNumber, email = @email, registration_date = @registrationDate, status = @status WHERE id_client = @id";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@firstName", entity.Nombre);
            cmd.Parameters.AddWithValue("@lastName", entity.Apellido);
            cmd.Parameters.AddWithValue("@phoneNumber", entity.Telefono);
            cmd.Parameters.AddWithValue("@email", entity.Correo);
            cmd.Parameters.AddWithValue("@registrationDate", entity.FechaRegistro);
            cmd.Parameters.AddWithValue("@status", entity.Estado);
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
