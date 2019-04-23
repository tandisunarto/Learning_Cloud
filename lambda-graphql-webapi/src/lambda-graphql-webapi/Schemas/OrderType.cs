using GraphQL.Types;
using lambda_graphql_webapi.Models;
using lambda_graphql_webapi.Services;

namespace lambda_graphql_webapi.Schemas
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(ICustomerService customerService)
        {
            Field(o => o.Id);
            Field(o => o.Name);
            Field(o => o.Description);
            Field<CustomerType>(
                "customer",
                resolve: context => customerService.GetCustomerByIdAsync(context.Source.CustomerId)
            );
            Field(o => o.Created);
        }
    }
}