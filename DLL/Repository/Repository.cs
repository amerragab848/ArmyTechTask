﻿using DLL.EF;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ArmyTechTaskEntities context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(ArmyTechTaskEntities context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        //public T Get(long id)
        //{
        //    // return entities.SingleOrDefault(s => s.Id == id);
        //}
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public List<T> GetUsersDataByManagerId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
