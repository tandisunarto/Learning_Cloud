using System.Collections.Generic;
using System.Threading.Tasks;
using lambda_graphql_webapi.Models;

namespace lambda_graphql_webapi.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrderByIdAsync(string id);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> CreateAsync(Order order);
        Task<Order> StartAsync(string orderId);
    }
}