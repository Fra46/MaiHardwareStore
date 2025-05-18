using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class CotizacionRepository : BaseDatos, IDBRepository<Cotizacion>
    {
        public CotizacionRepository()
        {
        }

        public List<Cotizacion> Consultar()
        {
            List<Cotizacion> lista = new List<Cotizacion>();
            string sentencia = "SELECT * FROM quotation";
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
            string sentencia = "DELETE FROM quotation WHERE id_quotation = @id";
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

        public string Guardar(Cotizacion entity)
        {
            string sentencia = "INSERT INTO quotation (id_client, id_user, date, total) VALUES (@clientId, @userId, @date, @total)";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@clientId", entity.Cliente.Id);
            cmd.Parameters.AddWithValue("@userId", entity.Empleado.Id);
            cmd.Parameters.AddWithValue("@date", entity.Fecha);
            cmd.Parameters.AddWithValue("@total", entity.Total);

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

        public Cotizacion Mappear(SqlDataReader reader)
        {
            Cotizacion cotizacion = new Cotizacion();
            cotizacion.Id = (int)reader["id_quotation"];
            cotizacion.Cliente = new Cliente { Id = (int)reader["id_client"] };
            cotizacion.Empleado = new Empleado { Id = (int)reader["id_user"] };
            cotizacion.Fecha = (DateTime)reader["date"];
            cotizacion.Total = (decimal)reader["total"];
            cotizacion.Detalles = ObtenerDetalles(cotizacion.Id);
            return cotizacion;
        }

        private List<DetalleCotizacion> ObtenerDetalles(int idCotizacion)
        {
            List<DetalleCotizacion> detalles = new List<DetalleCotizacion>();
            string sentencia = "SELECT * FROM quotation_detail WHERE id_quotation = @idCotizacion";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);
            cmd.Parameters.AddWithValue("@idCotizacion", idCotizacion);

            AbrirConexion();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DetalleCotizacion detalle = new DetalleCotizacion
                {
                    Id = (int)reader["id_quotation_detail"],
                    Producto = new Producto { Id = (int)reader["id_product"] },
                    Cantidad = (int)reader["quantity"],
                    PrecioUnitario = (decimal)reader["unit_price"]
                };
                detalles.Add(detalle);
            }
            CerrarConexion();
            return detalles;
        }

        public string Modificar(Cotizacion entity)
        {
            string sentencia = "UPDATE quotation SET id_client = @clientId, id_user = @userId, date = @date, total = @total WHERE id_quotation = @id";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@clientId", entity.Cliente.Id);
            cmd.Parameters.AddWithValue("@userId", entity.Empleado.Id);
            cmd.Parameters.AddWithValue("@date", entity.Fecha);
            cmd.Parameters.AddWithValue("@total", entity.Total);
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
