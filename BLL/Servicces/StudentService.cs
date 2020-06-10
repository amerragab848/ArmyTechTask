using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessL.EF;
using DataAccessL.Repository;
namespace BLL.Servicces
{
    public  class StudentService
    {
        ArmyTechTaskEntities context = new ArmyTechTaskEntities();

        private IBaserepository<Student> repository;
        FieldService fieldService = new FieldService();
        GovernorateService governorateService = new GovernorateService();
        NeighborhoodService neighborhoodService = new NeighborhoodService();

        public StudentService()
        {
            this.repository = new StudentRepository(new ArmyTechTaskEntities());
        }

        //public EmployeeService()
        //{
        //}

        public IEnumerable<Student> GetAllStudents()
        {
            var student = repository.GetAll();
            if (student != null)
            {
                return student;
            }
            return new List<Student>();
        }
        public Student GetStudentById(int? id)
        {
            var student = GetAllStudents().Where(c => c.ID == id).FirstOrDefault();
            return student;
        }
        public void InsertStudent(Student entity)
        {
            if (entity != null)
            {
                repository.Insert(entity);
            }
        }
        public void UpdateStudent(Student entity)
        {
            if (entity != null)
            {
                repository.Update(entity);
            }
        }
        public void DeleteStudent(Student entity)
        {
            if (entity != null)
            {
                repository.Delete(entity);
            }
        }
    }
}
