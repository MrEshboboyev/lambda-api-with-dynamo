using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ProductApi;

public class Function
{
    public async Task<APIGatewayProxyResponse> FunctionHandler(Function function)
    {
        Console.WriteLine("FunctionHandler called");

        return new APIGatewayProxyResponse()
        {
            StatusCode = 200,
            Body = "Product added successfully!"
        };
    }
}