using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cart.WebSite.Models
{
    public interface IGenericRepository<T> where T : class
    {
        T GetOrders(int id);
        IEnumerable<T> GetAllOrders();
        T Add(T obj);
        T Update(T objUpdate);
        T Delete(int id);
    }
}
