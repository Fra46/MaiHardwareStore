using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class AdministradorService : IService<Administrador>
    {
        private readonly AdministradorRepository administradorRepository;

        public AdministradorService()
        {
            administradorRepository = new AdministradorRepository();
        }

        public List<Administrador> Consultar()
        {
            return administradorRepository.Consultar();
        }

        public string Guardar(Administrador entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el propietario no puede ser nulo");
                }
                return administradorRepository.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar el propietario {ex.Message}";
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
                return administradorRepository.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el propietario {ex.Message}";
            }
        }

        public string Modificar(Administrador entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el propietario no puede ser nulo");
                }
                return administradorRepository.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar el propietario {ex.Message}";
            }
        }

        public Administrador BuscarId(int id)
        {
            var administradorBuscado = Consultar().FirstOrDefault<Administrador>(x => x.Id == id);
            return administradorBuscado;
        }
    }
}
