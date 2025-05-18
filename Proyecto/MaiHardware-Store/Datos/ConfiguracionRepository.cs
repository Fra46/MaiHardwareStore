using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class ConfiguracionRepository : BaseDatos, IDBRepository<Configuracion>
    {
        public ConfiguracionRepository()
        {
        }

        public List<Configuracion> Consultar()
        {
            List<Configuracion> lista = new List<Configuracion>();
            string sentencia = "SELECT * FROM config";
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
            string sentencia = "DELETE FROM config WHERE id_config = @id";
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

        public string Guardar(Configuracion entity)
        {
            string sentencia = "INSERT INTO config (store_name, igv, default_printer) VALUES (@storeName, @igv, @defaultPrinter)";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@storeName", entity.NombreTienda);
            cmd.Parameters.AddWithValue("@igv", entity.IVA);
            cmd.Parameters.AddWithValue("@defaultPrinter", entity.ImpresoraPredeterminada);

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

        public Configuracion Mappear(SqlDataReader reader)
        {
            Configuracion configuracion = new Configuracion();
            configuracion.Id = (int)reader["id_config"];
            configuracion.NombreTienda = (string)reader["store_name"];
            configuracion.IVA = (decimal)reader["igv"];
            configuracion.ImpresoraPredeterminada = (string)reader["default_printer"];
            return configuracion;
        }

        public string Modificar(Configuracion entity)
        {
            string sentencia = "UPDATE config SET store_name = @storeName, igv = @igv, default_printer = @defaultPrinter WHERE id_config = @id";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@storeName", entity.NombreTienda);
            cmd.Parameters.AddWithValue("@igv", entity.IVA);
            cmd.Parameters.AddWithValue("@defaultPrinter", entity.ImpresoraPredeterminada);
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
