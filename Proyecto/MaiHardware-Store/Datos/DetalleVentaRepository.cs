using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class DetalleVentaRepository : BaseDatos, IDBRepository<DetalleVenta>
    {
        public DetalleVentaRepository()
        {
        }

        public List<DetalleVenta> Consultar()
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            string sentencia = "SELECT * FROM sale_detail";
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
            string sentencia = "DELETE FROM sale_detail WHERE id_sale_detail = @id";
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

        public string Guardar(DetalleVenta entity)
        {
            string sentencia = "INSERT INTO sale_detail (id_sale, id_product, quantity, unit_price) VALUES (@saleId, @productId, @quantity, @unitPrice)";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@saleId", entity.Venta.Id);
            cmd.Parameters.AddWithValue("@productId", entity.Producto.Id);
            cmd.Parameters.AddWithValue("@quantity", entity.Cantidad);
            cmd.Parameters.AddWithValue("@unitPrice", entity.PrecioUnitario);

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

        public DetalleVenta Mappear(SqlDataReader reader)
        {
            DetalleVenta detalleVenta = new DetalleVenta();
            detalleVenta.Id = (int)reader["id_sale_detail"];
            detalleVenta.Venta = new Venta { Id = (int)reader["id_sale"] };
            detalleVenta.Producto = new Producto { Id = (int)reader["id_product"] };
            detalleVenta.Cantidad = (int)reader["quantity"];
            detalleVenta.PrecioUnitario = (decimal)reader["unit_price"];
            return detalleVenta;
        }

        public string Modificar(DetalleVenta entity)
        {
            string sentencia = "UPDATE sale_detail SET id_sale = @saleId, id_product = @productId, quantity = @quantity, unit_price = @unitPrice WHERE id_sale_detail = @id";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@saleId", entity.Venta.Id);
            cmd.Parameters.AddWithValue("@productId", entity.Producto.Id);
            cmd.Parameters.AddWithValue("@quantity", entity.Cantidad);
            cmd.Parameters.AddWithValue("@unitPrice", entity.PrecioUnitario);
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
