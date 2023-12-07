using Grp3_GrpVI_ITELEC1C.Models;

namespace Grp3_GrpVI_ITELEC1C.Services
{
    public interface IOrderDataService
    {
        Task<List<Order>> GetOrderAsync();
    }
}