using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

using Newtonsoft.Json;

using LambdaShoppingListWebAPI;


namespace LambdaShoppingListWebAPI.Tests
{
    public class ShoppingListControllerTests
    {
        [Fact]
        public async Task TestGet()
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/ShoppingList-Get.json");
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var context = new TestLambdaContext();
            var response = await lambdaFunction.FunctionHandlerAsync(request, context);

            Assert.Equal(200, response.StatusCode);
            // Assert.Equal("[\"value1\",\"value2\"]", response.Body);
            // Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
            // Assert.Equal("application/json; charset=utf-8", response.MultiValueHeaders["Content-Type"][0]);
        }

        [Fact]
        public async Task TestPost()
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/ShoppingList-Post.json");
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var context = new TestLambdaContext();
            var response = await lambdaFunction.FunctionHandlerAsync(request, context);

            Assert.Equal(201, response.StatusCode);

            // var requestGetStr = File.ReadAllText("./SampleRequests/ShoppingList-Get.json");
            // var requestGet = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestGetStr);
            // var responseGet = await lambdaFunction.FunctionHandlerAsync(request, context);

            // Assert.Equal(200, responseGet.StatusCode);
            // Assert.Equal("[\"value1\",\"value2\"]", responseGet.Body);
            // Assert.True(responseGet.MultiValueHeaders.ContainsKey("Content-Type"));
            // Assert.Equal("application/json; charset=utf-8", responseGet.MultiValueHeaders["Content-Type"][0]);
        }

    }
}
