using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class DetalleCotizacionService : IService<DetalleCotizacion>
    {
        private readonly DetalleCotizacionRepository detalleCotizacionRepository;

        public DetalleCotizacionService()
        {
            detalleCotizacionRepository = new DetalleCotizacionRepository();
        }

        public List<DetalleCotizacion> Consultar()
        {
            return detalleCotizacionRepository.Consultar();
        }

        public string Guardar(DetalleCotizacion entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el producto no puede ser nulo");
                }
                return detalleCotizacionRepository.Guardar(entity);
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
                return detalleCotizacionRepository.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el producto {ex.Message}";
            }
        }
        public string Modificar(DetalleCotizacion entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el producto no puede ser nulo");
                }
                return detalleCotizacionRepository.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar el producto {ex.Message}";
            }
        }

        public DetalleCotizacion BuscarId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
