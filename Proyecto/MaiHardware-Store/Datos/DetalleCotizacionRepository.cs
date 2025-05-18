using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class DetalleCotizacionRepository : BaseDatos, IDBRepository<DetalleCotizacion>
    {
        public DetalleCotizacionRepository()
        {
        }

        public List<DetalleCotizacion> Consultar()
        {
            List<DetalleCotizacion> lista = new List<DetalleCotizacion>();
            string sentencia = "SELECT * FROM quotation_detail";
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
            string sentencia = "DELETE FROM quotation_detail WHERE id_quotation_detail = @id";
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

        public string Guardar(DetalleCotizacion entity)
        {
            string sentencia = "INSERT INTO quotation_detail (id_quotation, id_product, quantity, unit_price) VALUES (@cotizacionId, @productoId, @cantidad, @precioUnitario)";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@cotizacionId", entity.Cotizacion.Id);
            cmd.Parameters.AddWithValue("@productoId", entity.Producto.Id);
            cmd.Parameters.AddWithValue("@cantidad", entity.Cantidad);
            cmd.Parameters.AddWithValue("@precioUnitario", entity.PrecioUnitario);

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

        public DetalleCotizacion Mappear(SqlDataReader reader)
        {
            DetalleCotizacion detalleCotizacion = new DetalleCotizacion();
            detalleCotizacion.Id = (int)reader["id_quotation_detail"];
            detalleCotizacion.Cotizacion = new Cotizacion { Id = (int)reader["id_quotation"] };
            detalleCotizacion.Producto = new Producto { Id = (int)reader["id_product"] };
            detalleCotizacion.Cantidad = (int)reader["quantity"];
            detalleCotizacion.PrecioUnitario = (decimal)reader["unit_price"];
            return detalleCotizacion;
        }

        public string Modificar(DetalleCotizacion entity)
        {
            string sentencia = "UPDATE quotation_detail SET id_quotation = @cotizacionId, id_product = @productoId, quantity = @cantidad, unit_price = @precioUnitario WHERE id_quotation_detail = @id";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@cotizacionId", entity.Cotizacion.Id);
            cmd.Parameters.AddWithValue("@productoId", entity.Producto.Id);
            cmd.Parameters.AddWithValue("@cantidad", entity.Cantidad);
            cmd.Parameters.AddWithValue("@precioUnitario", entity.PrecioUnitario);
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
