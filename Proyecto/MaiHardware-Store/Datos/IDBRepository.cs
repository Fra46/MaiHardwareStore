using System.Collections.Generic;

namespace Datos
{
    public interface IDBRepository<T>
    {
        string Guardar(T entity);
        List<T> Consultar();
        string Modificar(T entity);
        string Eliminar(int id);
    }
}
