using GraphQL.Types;
using lambda_graphql_webapi.Models;

namespace lambda_graphql_webapi.Schemas
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(c => c.Id);
            Field(c => c.Name);
        }
    }
}