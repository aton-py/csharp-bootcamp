using System.Collections.Generic;
using series_crud.Interfaces;

namespace series_crud
{
    public class RepositorySerie : IRepository<Series>
    {
        private List<Series> seriesList = new List<Series>();
        public void Exclude(int id)
        {
            seriesList[id].Delete();
        }

        public void Insert(Series entity)
        {
            seriesList.Add(entity);
        }

        public int NextId()
        {
            return seriesList.Count;
        }

        public void Refresh(int id, Series entity)
        {
            seriesList[id] = entity;
        }

        public Series ReturnById(int id)
        {
            return seriesList[id];
        }

        public List<Series> _List()
        {
            return seriesList;
        }
    }
}