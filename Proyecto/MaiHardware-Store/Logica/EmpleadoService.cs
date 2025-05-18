using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class EmpleadoService : IService<Empleado>
    {
        private readonly EmpleadoRepository empleadoRepository;

        public EmpleadoService()
        {
            empleadoRepository = new EmpleadoRepository();
        }

        public List<Empleado> Consultar()
        {
            return empleadoRepository.Consultar();
        }
        public string Guardar(Empleado entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el empleado no puede ser nulo");
                }
                return empleadoRepository.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar el empleado {ex.Message}";
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
                return empleadoRepository.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el empleado {ex.Message}";
            }
        }

        public string Modificar(Empleado entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el empleado no puede ser nulo");
                }
                return empleadoRepository.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar el empleado {ex.Message}";
            }
        }

        public Empleado BuscarId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
