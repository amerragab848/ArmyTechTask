
using DataAccessL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataAccessL.Repository
{
    public class StudentRepository : IBaserepository<Student> 
    {
        private readonly ArmyTechTaskEntities context;
       // private DbSet<Student> entities;
        string errorMessage = string.Empty;
        public StudentRepository(ArmyTechTaskEntities context)
        {
            this.context = context;
          //  entities = context.Set<Student>();
        }

        public void Delete(Student entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Students.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<Student> GetAll()
        {
            var res= context.Students.Include(c => c.Field)
                .Include(a => a.Governorate).Include(s => s.Neighborhood);
            return res;
        }

        public Student GetByStdId(int? id)
        {
            var std = context.Students.Include(c => c.Governorate).Include(c=>c.Field).
                Include(c=>c.Neighborhood).
                FirstOrDefault(c => c.ID == id);
            return std;
        }

        public List<Student> GetUsersDataByManagerId(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Student entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Students.Add(entity);
            context.SaveChanges();
        }

        public void Update(Student entity)
        {
            try
            {
                if (entity != null)
                {
                    context.Students.Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public IEnumerable<T> GetAll()
        //{
        //    return entities.AsEnumerable();
        //}

        //public void Insert(T entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ArgumentNullException("entity");
        //    }
        //    entities.Add(entity);
        //    context.SaveChanges();
        //}
        //public void Update(T entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ArgumentNullException("entity");
        //    }
        //    context.SaveChanges();
        //}
        //public void Delete(T entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ArgumentNullException("entity");
        //    }
        //    entities.Remove(entity);
        //    context.SaveChanges();
        //}

        //public List<T> GetUsersDataByManagerId(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
