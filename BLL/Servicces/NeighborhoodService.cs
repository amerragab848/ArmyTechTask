using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessL.EF;
using DataAccessL.Repository;
namespace BLL.Servicces
{
    public class NeighborhoodService
    {
        ArmyTechTaskEntities context = new ArmyTechTaskEntities();

        private IRepository<Neighborhood> repository;
        public NeighborhoodService()
        {
            this.repository = new Repository<Neighborhood>(new ArmyTechTaskEntities());
        }

        //public EmployeeService()
        //{
        //}

        public IEnumerable<Neighborhood> GetAllNeighborhoods()
        {
            var neighborhood = repository.GetAll();
            if (neighborhood != null)
            {
                return neighborhood;
            }
            return new List<Neighborhood>();
        }
        public Neighborhood GetNeighborhoodById(int? id)
        {
            var neighborhood = GetAllNeighborhoods().Where(c => c.ID == id).FirstOrDefault();
            return neighborhood;
        }
        public void InsertNeighborhood(Neighborhood entity)
        {
            if (entity != null)
            {
                repository.Insert(entity);
            }
        }
        public void UpdateNeighborhood(Neighborhood entity)
        {
            if (entity != null)
            {
                repository.Update(entity);
            }
        }
        public void DeleteNeighborhood(Neighborhood entity)
        {
            if (entity != null)
            {
                repository.Delete(entity);
            }
        }
    }
}
