using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class ProductoService : IService<Producto>
    {
        private readonly ProductoRepository productoRepository;

        public ProductoService()
        {
            productoRepository = new ProductoRepository();
        }
        public List<Producto> Consultar()
        {
            return productoRepository.Consultar();
        }
        public string Guardar(Producto entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el producto no puede ser nulo");
                }
                return productoRepository.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar el producto {ex.Message}";
            }
        }
        public string Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Error... el id no puede ser menor a cero");
                }
                return productoRepository.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el producto {ex.Message}";
            }
        }
        public string Modificar(Producto entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el producto no puede ser nulo");
                }
                return productoRepository.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar el producto {ex.Message}";
            }
        }

        public Producto BuscarId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
