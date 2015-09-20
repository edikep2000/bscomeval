using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.Ajax.Utilities;
using Telerik.OpenAccess;

namespace TestApp.Service
{
    public class BaseService<T> where T: class
    {
        private readonly OpenAccessContext _context;

        protected BaseService(OpenAccessContext context)
        {
            _context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.GetAll<T>();
        }

        public virtual T GetSingle(object id)
        {
            var objectKey = new ObjectKey(typeof (T).Name, id);
            return _context.GetObjectByKey<T>(objectKey);
        }


        public virtual IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.GetAll<T>().Where(expression);
        }

        public virtual T Add(T t)
        {
             _context.Add(t);
            return t;
        }

        public virtual T Update(T t)
        {
            _context.AttachCopy(t);
            return t;
        }

        public virtual void Delete(object id)
        {
            var t = GetSingle(id);
            if (t != null)
            {
                _context.Delete(t);
            }
        }

        public virtual void Delete(T t)
        {
            _context.Delete(t);
        }
    }
}