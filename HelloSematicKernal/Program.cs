using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var builder = Kernel.CreateBuilder();

builder.Services.AddAzureOpenAIChatCompletion(
    config["AzureOpenAI:ModelId"],
    config["AzureOpenAI:Endpoint"],
    config["AzureOpenAI:ApiKey"]);

Kernel kernel = builder.Build();    

var result = await kernel.InvokePromptAsync("Give me some good resturants in my area");
