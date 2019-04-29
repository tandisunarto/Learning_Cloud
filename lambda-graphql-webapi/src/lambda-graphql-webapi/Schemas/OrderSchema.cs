using GraphQL;
using GraphQL.Types;

namespace lambda_graphql_webapi.Schemas
{
    public class OrderSchema : Schema
    {
        public OrderSchema(
            OrderQuery query,
            OrderMutation mutation,
            OrdersSubscription subscription,
            IDependencyResolver resolver
        )
        {
            Query = query;
            Mutation = mutation;
            DependencyResolver = resolver;
            Subscription = subscription;
        }
    }
}