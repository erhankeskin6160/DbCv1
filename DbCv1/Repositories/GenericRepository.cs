
using DbCv1.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
 

namespace DbCv1.Repositories
{
    public class GenericRepository<T>  where T:class,new()
    {
        DbCvEntities2 db = new DbCvEntities2();
       

        public  List<T> List() 
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T p) 
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void TDelete(T d) 
        {
            db.Set<T>().Remove(d);
            db.SaveChanges();
        }
        public T Get(int id) 
        {
            return db.Set<T>().Find(id);
        }

        public void TUpdate(T p) 
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T,bool>> where) 
        {
            return db.Set<T>().FirstOrDefault(where);
        }

    }
}