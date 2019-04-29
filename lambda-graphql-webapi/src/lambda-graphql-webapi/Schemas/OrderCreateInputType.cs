using GraphQL.Types;

namespace lambda_graphql_webapi.Schemas
{
    public class OrderCreateInputType : InputObjectGraphType
    {
        public OrderCreateInputType()
        {
            Name = "OrderInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("description");
            Field<NonNullGraphType<IntGraphType>>("customerId");
            Field<NonNullGraphType<DateGraphType>>("created");
        }
    }
}