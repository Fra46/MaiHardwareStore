using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class DetalleVentaService : IService<DetalleVenta>
    {
        private readonly DetalleVentaRepository detalleVentaRepository;

        public DetalleVentaService()
        {
            detalleVentaRepository = new DetalleVentaRepository();
        }
        public List<DetalleVenta> Consultar()
        {
            return detalleVentaRepository.Consultar();
        }
        public string Guardar(DetalleVenta entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el producto no puede ser nulo");
                }
                return detalleVentaRepository.Guardar(entity);
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
                return detalleVentaRepository.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el producto {ex.Message}";
            }
        }
        public string Modificar(DetalleVenta entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el producto no puede ser nulo");
                }
                return detalleVentaRepository.Modificar(entity);
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

        DetalleVenta IService<DetalleVenta>.BuscarId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
