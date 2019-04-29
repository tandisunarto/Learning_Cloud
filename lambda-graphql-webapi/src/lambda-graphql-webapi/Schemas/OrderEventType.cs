using GraphQL.Types;
using lambda_graphql_webapi.Models;

namespace lambda_graphql_webapi.Schemas
{
    public class OrderEventType : ObjectGraphType<OrderEvent>
    {
        public OrderEventType()
        {
            Field(e => e.Id);
            Field(e => e.Name);
            Field(e => e.OrderId);
            Field<OrderStatusesEnum>(
                "status",
                resolve: context => context.Source.Status
            );
            Field(e => e.Timestamp);
        }
    }
}