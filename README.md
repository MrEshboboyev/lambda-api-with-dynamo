
# Lambda API with DynamoDB and ASP.NET Core  

This repository provides a step-by-step implementation of building a serverless REST API using **AWS Lambda**, **DynamoDB**, and **ASP.NET Core**. The API enables seamless interaction with a DynamoDB table to manage product data on AWS.  

## 🌟 Features  
- **Serverless Architecture**: Powered by AWS Lambda for efficient and scalable backend.  
- **Database Integration**: Connects to DynamoDB for data storage and retrieval.  
- **ASP.NET Core**: Leverages .NET Core for building robust APIs.  
- **From Scratch**: A beginner-friendly guide to setting up the entire stack from the ground up.  

## 🚀 API Endpoint  
You can access the API at:  
[API Link](https://lwaqslrtbwwqrpnhxjoiceznnm0vprsw.lambda-url.us-east-1.on.aws/)  

## 📂 Repository Structure  
- **DynamoDB Setup**: Scripts and configuration for creating and managing the DynamoDB table.  
- **Lambda Function**: Implementation of AWS Lambda functions to handle API requests.  
- **ASP.NET Core API**: The API layer to interact with the database and handle client requests.  

## 🛠 Getting Started  

### Step 1: Prerequisites  
Ensure you have the following:  
- An AWS account  
- .NET Core SDK installed  
- AWS CLI configured with your credentials  

### Step 2: Clone the Repository  
```bash  
git clone https://github.com/MrEshboboyev/lambda-api-with-dynamo.git  
cd lambda-api-with-dynamo  
```  

### Step 3: Setup DynamoDB  
1. Create a DynamoDB table in the AWS Management Console.  
2. Define your table schema (e.g., `ProductId` as the primary key).  

### Step 4: Deploy the Lambda Function  
1. Build the project and package it as a zip file:  
    ```bash  
    dotnet publish -c Release -o out  
    cd out  
    zip -r lambda-package.zip *  
    ```  
2. Deploy the function using AWS CLI or the AWS Management Console.  

### Step 5: Test the API  
Use tools like Postman or Curl to test the provided API endpoints.  

## 🌐 API Endpoints  
Here’s a list of API endpoints available:  

| Method | Endpoint                             | Description                |  
|--------|-------------------------------------|----------------------------|  
| GET    | `/products`                         | Retrieve all products      |  
| GET    | `/products/{id}`                    | Retrieve a specific product|  
| POST   | `/products`                         | Add a new product          |  
| PUT    | `/products/{id}`                    | Update an existing product |  
| DELETE | `/products/{id}`                    | Delete a product           |  

## 📖 Code Highlights  

### Example: Adding a Product  
```csharp  
[HttpPost("products")]  
public async Task<IActionResult> AddProduct([FromBody] Product product)  
{  
    await _dynamoDbService.AddProductAsync(product);  
    return Ok(product);  
}  
```  

### Example: Retrieving All Products  
```csharp  
[HttpGet("products")]  
public async Task<IActionResult> GetProducts()  
{  
    var products = await _dynamoDbService.GetAllProductsAsync();  
    return Ok(products);  
}  
```  

## 🌟 Why Choose This Project?  
1. **End-to-End Example**: Learn how to integrate ASP.NET Core with AWS services step-by-step.  
2. **Scalable Solution**: Build APIs that scale effortlessly using serverless technology.  
3. **Real-World Use Case**: Manage products in a database with practical examples.  

## 🏗 About the Author  
This repository was created by [MrEshboboyev](https://github.com/MrEshboboyev), showcasing expertise in cloud computing and backend development.  

## 📄 License  
This project is licensed under the MIT License. Use it to build your own projects or learn more about serverless API development.  

## 🔖 Tags  
C#, ASP.NET Core, AWS Lambda, DynamoDB, Serverless, REST API, AWS, Cloud Computing, Database, Backend Development, API Integration  

---  

Feel free to suggest additional features or ask questions! 🚀  
