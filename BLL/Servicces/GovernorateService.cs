using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessL.EF;
using DataAccessL.Repository;
namespace BLL.Servicces
{
    public class GovernorateService
    {
        ArmyTechTaskEntities context = new ArmyTechTaskEntities();

        private IRepository<Governorate> repository;
        public GovernorateService()
        {
            this.repository = new Repository<Governorate>(new ArmyTechTaskEntities());
        }

        //public EmployeeService()
        //{
        //}

        public IEnumerable<Governorate> GetAllGovernorates()
        {
            var governorate = repository.GetAll();
            if (governorate != null)
            {
                return governorate;
            }
            return new List<Governorate>();
        }
        public Governorate GetGovernorateById(int? id)
        {
            var governorate = GetAllGovernorates().Where(c => c.ID == id).FirstOrDefault();
            return governorate;
        }
        public void InsertGovernorate(Governorate entity)
        {
            if (entity != null)
            {
                repository.Insert(entity);
            }
        }
        public void UpdateGovernorate(Governorate entity)
        {
            if (entity != null)
            {
                repository.Update(entity);
            }
        }
        public void DeleteGovernorate(Governorate entity)
        {
            if (entity != null)
            {
                repository.Delete(entity);
            }
        }
    }
}
