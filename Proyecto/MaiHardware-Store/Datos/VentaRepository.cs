using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class VentaRepository : BaseDatos, IDBRepository<Venta>
    {
        public VentaRepository()
        {
        }

        public List<Venta> Consultar()
        {
            List<Venta> lista = new List<Venta>();
            string sentencia = "SELECT * FROM sale";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            try
            {
                AbrirConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(Mappear(reader));
                    }
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
            string sentencia = "DELETE FROM sale WHERE id = @id";
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

        public string Guardar(Venta entity)
        {
            string sentencia = "INSERT INTO sale (date, payment_method, total, id_client, id_user) VALUES (@date, @paymentMethod, @total, @clientId, @userId)";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@date", entity.Fecha);
            cmd.Parameters.AddWithValue("@paymentMethod", entity.MetodoPago);
            cmd.Parameters.AddWithValue("@total", entity.Total);
            cmd.Parameters.AddWithValue("@clientId", entity.Cliente.Id);
            cmd.Parameters.AddWithValue("@userId", entity.Empleado.Id);

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

        public Venta Mappear(SqlDataReader reader)
        {
            Venta venta = new Venta();
            venta.Id = (int)reader["id_sale"];
            venta.Cliente = new Cliente { Id = (int)reader["id_client"] };
            venta.Empleado = new Empleado { Id = (int)reader["id_user"] };
            venta.Fecha = (DateTime)reader["date"];
            venta.MetodoPago = (string)reader["payment_method"];
            venta.Total = (decimal)reader["total"];
            venta.Detalles = ObtenerDetalles(venta.Id);
            return venta;
        }

        private List<DetalleVenta> ObtenerDetalles(int idVenta)
        {
            List<DetalleVenta> detalles = new List<DetalleVenta>();
            string sentencia = "SELECT * FROM sale_detail WHERE id_sale = @idVenta";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);
            cmd.Parameters.AddWithValue("@idVenta", idVenta);

            AbrirConexion();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DetalleVenta detalle = new DetalleVenta
                {
                    Id = (int)reader["id_sale_detail"],
                    Producto = new Producto { Id = (int)reader["id_product"] },
                    Cantidad = (int)reader["quantity"],
                    PrecioUnitario = (decimal)reader["unit_price"]
                };
                detalles.Add(detalle);
            }
            CerrarConexion();
            return detalles;
        }

        public string Modificar(Venta entity)
        {
            string sentencia = "UPDATE sale SET date = @date, payment_method = @paymentMethod, total = @total, id_client = @clientId, id_user = @userId WHERE id_sale = @id";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@date", entity.Fecha);
            cmd.Parameters.AddWithValue("@paymentMethod", entity.MetodoPago);
            cmd.Parameters.AddWithValue("@total", entity.Total);
            cmd.Parameters.AddWithValue("@clientId", entity.Cliente.Id);
            cmd.Parameters.AddWithValue("@userId", entity.Empleado.Id);
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
