using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAutoLotDaL.Repos
{
    public interface IRepo<T>
    {
        int Add(T entity);
        int AddRange(IList<T> entites);
        int Save(T entity);
        int Delete(int id, byte[] timeStamp);
        int Delete(T entity);
        T GetOne(int? id);
        List<T> GetAll();
        List<T> ExeciteQuery(string sql);
        List<T> ExecuteQuery(string sql, object[] sqlParametrsObjects);

    }
}
