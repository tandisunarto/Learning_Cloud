using System.Collections.Generic;
using System.Threading.Tasks;
using lambda_graphql_webapi.Models;

namespace lambda_graphql_webapi.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}