using System;
using GraphQL.Types;
using lambda_graphql_webapi.Models;
using lambda_graphql_webapi.Services;

namespace lambda_graphql_webapi.Schemas
{
    public class OrderMutation : ObjectGraphType<object>
    {
        public OrderMutation(IOrderService orderService)
        {
            Name = "Mutation";
            Field<OrderType>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderCreateInputType>>
                    {
                        Name = "order"
                    }
                ),
                resolve: context => {
                    var orderInput = context.GetArgument<OrderCreateInput>("order");
                    var id = Guid.NewGuid().ToString();
                    var order = new Order(orderInput.Name, orderInput.Description, orderInput.Created,
                        orderInput.CustomerId, id);
                    return orderService.CreateAsync(order);
                }
            );
            FieldAsync<OrderType>(
                "startOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>{ Name = "orderId"}
                ),
                resolve: async context => {
                    var orderId = context.GetArgument<string>("orderId");
                    return await context.TryAsyncResolve(
                        async c => await orderService.StartAsync(orderId)
                    );
                }
            );
        }
    }
}