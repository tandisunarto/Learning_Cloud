using GraphQL;
using GraphQL.Types;

namespace lambda_graphql_webapi.Schemas
{
    public class OrderSchema : Schema
    {
        public OrderSchema(
            OrderQuery query,
            IDependencyResolver resolver
        )
        {
            Query = query;
            DependencyResolver = resolver;
        }
    }
}