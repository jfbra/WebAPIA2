using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPIA2.Models;

namespace WebAPIA2.Data
{
    public class DBOrdersAPIRepo : IOrdersAPIRepo
    {
        private readonly WebAPIA2DBContext _dbContext;

        public DBOrdersAPIRepo(WebAPIA2DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            ValueTask<EntityEntry<Order>> o = _dbContext.Orders.AddAsync(order);
            await o;
            await _dbContext.SaveChangesAsync();
            return o.Result.Entity;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            IEnumerable<Order> orders = _dbContext.Orders.ToList<Order>();
            return orders;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
