using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class ClienteService : IService<Cliente>
    {
        private readonly ClienteRepository clienteRepository;
        public ClienteService()
        {
            clienteRepository = new ClienteRepository();
        }
        public List<Cliente> Consultar()
        {
            return clienteRepository.Consultar();
        }
        public string Guardar(Cliente entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el cliente no puede ser nulo");
                }
                return clienteRepository.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar el cliente {ex.Message}";
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
                return clienteRepository.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el cliente {ex.Message}";
            }
        }
        public string Modificar(Cliente entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el cliente no puede ser nulo");
                }
                return clienteRepository.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar el cliente {ex.Message}";
            }
        }

        public Cliente BuscarId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
