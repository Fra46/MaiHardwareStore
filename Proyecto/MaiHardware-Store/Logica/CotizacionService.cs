using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class CotizacionService : IService<Cotizacion>
    {
        private readonly CotizacionRepository cotizacionRepository;

        public List<Cotizacion> Consultar()
        {
            return cotizacionRepository.Consultar();
        }

        public string Guardar(Cotizacion entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el producto no puede ser nulo");
                }
                return cotizacionRepository.Guardar(entity);
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
                return cotizacionRepository.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el producto {ex.Message}";
            }
        }

        public string Modificar(Cotizacion entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el producto no puede ser nulo");
                }
                return cotizacionRepository.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar el producto {ex.Message}";
            }
        }

        public Cotizacion BuscarId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
