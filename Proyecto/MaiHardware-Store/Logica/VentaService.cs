using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class VentaService : IService<Venta>
    {
        private readonly VentaRepository ventaRepository;

        public VentaService()
        {
            ventaRepository = new VentaRepository();
        }

        public List<Venta> Consultar()
        {
            return ventaRepository.Consultar();
        }

        public string Guardar(Venta entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la venta no puede ser nula");
                }
                return ventaRepository.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar la venta {ex.Message}";
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
                return ventaRepository.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar la venta {ex.Message}";
            }
        }
        public string Modificar(Venta entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la venta no puede ser nula");
                }
                return ventaRepository.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar la venta {ex.Message}";
            }
        }

        public Venta BuscarId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
