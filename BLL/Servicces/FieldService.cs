
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//added
using DataAccessL.EF;
using DataAccessL.Repository;
namespace BLL.Servicces
{
    public class FieldService
    {
        ArmyTechTaskEntities context = new ArmyTechTaskEntities();

        private IRepository<Field> repository; 
        public FieldService()
        {
            this.repository = new Repository<Field>(new ArmyTechTaskEntities());
        }

        //public EmployeeService()
        //{
        //}

        public IEnumerable<Field> GetAllFields()
        {
            var field = repository.GetAll();
            if (field != null)
            {
                return field;
            }
            return new List<Field>();
        }
        public Field GetFieldById(int? id)
        {
            var field = GetAllFields().Where(c => c.ID == id).FirstOrDefault();
            return field;
        }
        public void InsertField(Field entity)
        {
            if (entity != null)
            {
                repository.Insert(entity);
            }
        }
        public void UpdateField(Field entity)
        {
            if (entity != null)
            {
                repository.Update(entity);
            }
        }
        public void DeleteField(Field entity)
        {
            if (entity != null)
            {
                repository.Delete(entity);
            }
        }

    }
}
