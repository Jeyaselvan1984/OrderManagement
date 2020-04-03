﻿using OrderManagement.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OrderManagement.EntityFrameworkDataAccess;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T> where T : class
    {
        private OrderManagementContext _context;
        public EFGenericRepository()
        {
            _context = new OrderManagementContext();
        }
        public void Add(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            _context.SaveChanges();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (Expression<Func<T, object>> property in navigationProperties)
            {

                dbQuery = dbQuery.Include<T, object>(property);
            }
            return dbQuery.ToList();

        }

        public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (
                Expression<Func<T, object>> property in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(property);

            }
            return dbQuery.Where(where).ToList<T>();
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (
                Expression<Func<T, object>> property in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(property);
            }
            return dbQuery.Where(where).FirstOrDefault();
        }

        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}