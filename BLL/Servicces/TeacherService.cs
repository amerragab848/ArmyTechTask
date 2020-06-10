using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessL.EF;
using DataAccessL.Repository;
namespace BLL.Servicces
{
    public class TeacherService
    {
        ArmyTechTaskEntities context = new ArmyTechTaskEntities();

        private IRepository<Teacher> repository;
        public TeacherService()
        {
            this.repository = new Repository<Teacher>(new ArmyTechTaskEntities());
        }

        //public EmployeeService()
        //{
        //}

        public IEnumerable<Teacher> GetAllTeachers()
        {
            var teacher = repository.GetAll();
            if (teacher != null)
            {
                return teacher;
            }
            return new List<Teacher>();
        }
        public Teacher GetTeacherById(int? id)
        {
            var teacher = GetAllTeachers().Where(c => c.ID == id).FirstOrDefault();
            return teacher;
        }
        public void InsertTeacher(Teacher entity)
        {
            if (entity != null)
            {
                repository.Insert(entity);
            }
        }
        public void UpdateTeacher(Teacher entity)
        {
            if (entity != null)
            {
                repository.Update(entity);
            }
        }
        public void DeleteTeacher(Teacher entity)
        {
            if (entity != null)
            {
                repository.Delete(entity);
            }
        }
    }
}
