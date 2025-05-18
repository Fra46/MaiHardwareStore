using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class ReporteService : IService<Reporte>
    {
        private readonly ReporteRepository reporteRepository;

        public ReporteService()
        {
            reporteRepository = new ReporteRepository();
        }

        public List<Reporte> Consultar()
        {
            return reporteRepository.Consultar();
        }

        public string Guardar(Reporte entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la venta no puede ser nula");
                }
                return reporteRepository.Guardar(entity);
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
                return reporteRepository.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar la venta {ex.Message}";
            }
        }
        public string Modificar(Reporte entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la venta no puede ser nula");
                }
                return reporteRepository.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar la venta {ex.Message}";
            }
        }

        public Reporte BuscarId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
