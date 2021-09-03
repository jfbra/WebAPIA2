using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIA2.Models;

namespace WebAPIA2.Data
{
    public interface IOrdersAPIRepo
    {
        Task<Order> AddOrderAsync(Order order);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task SaveChangesAsync();
    }
}
