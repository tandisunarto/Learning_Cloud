using GraphQL.Types;
using lambda_graphql_webapi.Models;
using lambda_graphql_webapi.Services;

namespace lambda_graphql_webapi.Schemas
{
    public class OrderQuery : ObjectGraphType<object>
    {
        public OrderQuery(IOrderService orderService)
        {
            Name = "Query";
            Description = "This is a Query for Orders";
            Field<ListGraphType<OrderType>>(
                "orders",
                resolve: context => orderService.GetOrdersAsync()
            );
        }
    }
}