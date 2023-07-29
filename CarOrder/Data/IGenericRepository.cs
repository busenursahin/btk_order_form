using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOrder.Data
{
    public interface IGenericRepository<T> where T : class , new()
    {
        T Add(T entity);
        List<T> GetList();
        List<T> GetListWithFK(string fkTable);
        List<T> GetListWhere(string fkTable, int id);

        void Delete(T entity);
        void Update(T entity);
        T Get();
        
    }
}
