using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class ConfiguracionService : IService<Configuracion>
    {
        private readonly ConfiguracionRepository configuracionRepository;

        public ConfiguracionService()
        {
            configuracionRepository = new ConfiguracionRepository();
        }

        public List<Configuracion> Consultar()
        {
            return configuracionRepository.Consultar();
        }

        public string Guardar(Configuracion entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el producto no puede ser nulo");
                }
                return configuracionRepository.Guardar(entity);
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
                return configuracionRepository.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el producto {ex.Message}";
            }
        }
        public string Modificar(Configuracion entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el producto no puede ser nulo");
                }
                return configuracionRepository.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar el producto {ex.Message}";
            }
        }

        public Configuracion BuscarId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
