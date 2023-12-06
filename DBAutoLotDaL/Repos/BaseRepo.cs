using DBAutoLotDaL.EF;
using DBAutoLotDaL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAutoLotDaL.Repos
{
    public class BaseRepo<T> : IDisposable, IRepo<T> where T : EntityBase, new()
    {
        private readonly DbSet<T> _table;
        private readonly AutoLotEntities _db;
        public BaseRepo()
        {
            _db = new AutoLotEntities();
            _table = _db.Set<T>();
        }
        protected AutoLotEntities context=> _db;
        internal int saveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }catch(DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch(CommitFailedException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public int Add(T entity)
        {
            _table.Add(entity);
            return saveChanges();
        }

        public int AddRange(IList<T> entites)
        {
            _table.AddRange(entites);
            return saveChanges();
        }

        public int Delete(int id, byte[] timeStamp)
        {
           _db.Entry(new T() { Id=id,Timestamp=timeStamp}).State=EntityState.Deleted;
            return saveChanges();
        }

        public int Delete(T entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            return saveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public List<T> ExeciteQuery(string sql)
        {
            return _table.SqlQuery(sql).ToList();
        }

        public List<T> ExecuteQuery(string sql, object[] sqlParametrsObjects)
        {
            return _table.SqlQuery(sql,sqlParametrsObjects).ToList();
        }

        public virtual List<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetOne(int? id)
        {
            return _table.Find(id);
        }

        public int Save(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return saveChanges();   
        }
    }
}
