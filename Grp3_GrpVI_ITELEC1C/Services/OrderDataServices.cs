using Grp3_GrpVI_ITELEC1C.Data;
using Grp3_GrpVI_ITELEC1C.Models;
using Microsoft.EntityFrameworkCore;

namespace Grp3_GrpVI_ITELEC1C.Services
{
    public class OrderDataServices : IOrderDataService
    {
        private AppDbContext _appDbContext;

        public OrderDataServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Order>> GetOrderAsync()
        {
            var orders = await _appDbContext.Orders.ToListAsync();
            return orders;
        }

        public async Task DeleteOrderAsync(Order order)
        {
            var selectedOrder = await _appDbContext.Orders.Where(x => order.Id == x.Id).FirstOrDefaultAsync();

            if (selectedOrder != null)
            {
                _appDbContext.Orders.Remove(selectedOrder);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
