﻿using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using ProductApi.Models;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ProductApi;

public class Function
{
    private static readonly IAmazonDynamoDB _client = 
            new AmazonDynamoDBClient(
                Environment.GetEnvironmentVariable("AccessKey"),
                Environment.GetEnvironmentVariable("SecretKey"),
            new AmazonDynamoDBConfig
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            });
    
    private static readonly Table _table = new TableBuilder(_client, "Products")
        .AddHashKey("ProductId", DynamoDBEntryType.String)
        .Build();
    
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request)
    {
        Console.WriteLine("FunctionHandler called");
        
        var product = JsonSerializer.Deserialize<Product>(request.Body);

        if (product == null)
        {
            return new APIGatewayProxyResponse()
            {
                StatusCode = 400,
                Body = "Invalid product data",
            };
        }
        
        var document = new Document()
        {
            ["ProductId"] = product.ProductId,
            ["Name"] = product.Name,
            ["Price"] = product.Price
        };
        
        await _table.PutItemAsync(document);

        Console.WriteLine("Product added successfully!");

        return new APIGatewayProxyResponse()
        {
            StatusCode = 200,
            Body = "Product added successfully!"
        };
    }
}