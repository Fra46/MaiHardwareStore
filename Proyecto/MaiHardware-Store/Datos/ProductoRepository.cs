using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class ProductoRepository : BaseDatos, IDBRepository<Producto>
    {
        public ProductoRepository()
        {
        }

        public List<Producto> Consultar()
        {
            List<Producto> lista = new List<Producto>();
            string sentencia = "SELECT * FROM product";
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
            string sentencia = "DELETE FROM product WHERE id = @id";
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

        public string Guardar(Producto entity)
        {
            string sentencia = "INSERT INTO product (code, name, category, description, sale_price, stock) VALUES (@code, @name, @category, @description, @salePrice, @stock)";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@code", entity.Codigo);
            cmd.Parameters.AddWithValue("@name", entity.Nombre);
            cmd.Parameters.AddWithValue("@category", entity.Categoria);
            cmd.Parameters.AddWithValue("@description", entity.Descripcion);
            cmd.Parameters.AddWithValue("@salePrice", entity.Precio);
            cmd.Parameters.AddWithValue("@stock", entity.Stock);

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

        public Producto Mappear(SqlDataReader reader)
        {
            Producto producto = new Producto();
            producto.Id = (int)reader["id_product"];
            producto.Codigo = (string)reader["code"];
            producto.Nombre = (string)reader["name"];
            producto.Categoria = (string)reader["category"];
            producto.Descripcion = (string)reader["description"];
            producto.Precio = (decimal)reader["sale_price"];
            producto.Stock = (int)reader["stock"];
            return producto;
        }

        public string Modificar(Producto entity)
        {
            string sentencia = "UPDATE product SET code = @code, name = @name, category = @category, description = @description, sale_price = @salePrice, stock = @stock WHERE id_product = @id";
            SqlCommand cmd = new SqlCommand(sentencia, Connection);

            cmd.Parameters.AddWithValue("@code", entity.Codigo);
            cmd.Parameters.AddWithValue("@name", entity.Nombre);
            cmd.Parameters.AddWithValue("@category", entity.Categoria);
            cmd.Parameters.AddWithValue("@description", entity.Descripcion);
            cmd.Parameters.AddWithValue("@salePrice", entity.Precio);
            cmd.Parameters.AddWithValue("@stock", entity.Stock);
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
