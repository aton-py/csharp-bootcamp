using System.Collections.Generic;

namespace series_crud.Interfaces
{
    public interface IRepository<T>
    {
        List<T> _List();
        T ReturnById(int id);
        void Insert(T entity);
        void Exclude(int id);
        void Update(int id, T entity);
        int NextId();
    }
}