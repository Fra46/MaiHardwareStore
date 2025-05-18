using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class ReporteRepository : BaseDatos, IDBRepository<Reporte>
    {
        public ReporteRepository()
        {
        }

        public List<Reporte> Consultar()
        {
            List<Reporte> lista = new List<Reporte>();
            string sentencia = "SELECT id, fecha_inicio, fecha_fin FROM reports";
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
            string sentencia = "DELETE FROM reports WHERE id = @id";
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

        public string Guardar(Reporte entity)
        {
            string sentencia = "INSERT INTO reports (fecha_inicio, fecha_fin) VALUES (@fechaInicio, @fechaFin)";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@fechaInicio", entity.FechaInicio);
            cmd.Parameters.AddWithValue("@fechaFin", entity.FechaFin);

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

        public Reporte Mappear(SqlDataReader reader)
        {
            Reporte reporte = new Reporte();
            reporte.Id = (int)reader["id"];
            reporte.FechaInicio = (DateTime)reader["fecha_inicio"];
            reporte.FechaFin = (DateTime)reader["fecha_fin"];
            reporte.Ventas = ObtenerVentas(reporte.FechaInicio, reporte.FechaFin);
            reporte.ProductosMasVendidos = ObtenerProductosMasVendidos(reporte.FechaInicio, reporte.FechaFin);
            return reporte;
        }

        private List<Venta> ObtenerVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Venta> ventas = new List<Venta>();
            string sentencia = "SELECT * FROM sale WHERE date >= @fechaInicio AND date <= @fechaFin";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);
            cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
            cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

            AbrirConexion();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Venta venta = new Venta
                {
                    Id = (int)reader["id_sale"],
                    Fecha = (DateTime)reader["date"],
                    MetodoPago = (string)reader["payment_method"],
                    Total = (decimal)reader["total"],
                    Cliente = new Cliente { Id = (int)reader["id_client"] },
                    Empleado = new Empleado { Id = (int)reader["id_user"] }
                };
                ventas.Add(venta);
            }
            CerrarConexion();
            return ventas;
        }

        private List<Producto> ObtenerProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Producto> productos = new List<Producto>();
            string sentencia = @"
                SELECT TOP 10 p.*
                FROM sale_detail sd
                INNER JOIN product p ON sd.id_product = p.id_product
                INNER JOIN sale s ON sd.id_sale = s.id_sale
                WHERE s.date >= @fechaInicio AND s.date <= @fechaFin
                GROUP BY p.id_product, p.code, p.name, p.category, p.description, p.sale_price, p.stock
                ORDER BY SUM(sd.quantity) DESC";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);
            cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
            cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

            AbrirConexion();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Producto producto = new Producto
                {
                    Id = (int)reader["id_product"],
                    Codigo = (string)reader["code"],
                    Nombre = (string)reader["name"],
                    Categoria = (string)reader["category"],
                    Descripcion = (string)reader["description"],
                    Precio = (decimal)reader["sale_price"],
                    Stock = (int)reader["stock"]
                };
                productos.Add(producto);
            }
            CerrarConexion();
            return productos;
        }

        public string Modificar(Reporte entity)
        {
            string sentencia = "UPDATE reports SET fecha_inicio = @fechaInicio, fecha_fin = @fechaFin WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@fechaInicio", entity.FechaInicio);
            cmd.Parameters.AddWithValue("@fechaFin", entity.FechaFin);
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
