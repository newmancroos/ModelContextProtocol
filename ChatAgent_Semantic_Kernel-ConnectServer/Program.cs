using ChatAgent_Semantic_Kernel_ConnectServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using ModelContextProtocol.Client;

//Populate values from your OpenAi deployment (Azure AI foundry)
var modelId = "gpt-4o"; // "gpt-4o"; // "gpt-3.5-turbo"; // "gpt-4.1"; // "gpt-4o-mini";
var endpoint = "https://api.openai.com";
var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY", EnvironmentVariableTarget.User);





//Create a kernel and add the Azure OpenAI chat completion service
//Other than Chat agent there are other Agents too
var builder = Kernel.CreateBuilder()
    .AddOpenAIChatCompletion(modelId: modelId, endpoint: new Uri(endpoint), apiKey: apiKey);  //.AddAzureOpenAIChatCompletion(modelId, endpoint, apiKey);

builder.Services.AddLogging(services => services.AddConsole().SetMinimumLevel(LogLevel.Trace));

//---------------------MCP : Creating MCPclient transport to call MCP Server---------------------------------
var clientTransport = new HttpClientTransport(new HttpClientTransportOptions
{
    Endpoint = new Uri("http://localhost:5268"), // Endpoint of the MCP Server
});

var client = await McpClient.CreateAsync(clientTransport);

var tools = await client.ListToolsAsync();

foreach (var tool in tools)
{
    Console.WriteLine($"{tool.Name}, {tool.Description}");
}
//-----------------------------------------------------------------------------------------------------------

//Build the kernel
Kernel kernel = builder.Build();    

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

//Add a plugin LightPlugin. Plugins are tools that can be used in the context of a conversation.
//They can be used to extend the capabilities of the model by providing additional functionality.

//kernel.Plugins.AddFromType<LightPlugin>("Lights");
//kernel.Plugins.AddFromType<WeatherPlugin>("Weather");

//---------------------MCP : Creating MCPclient transport to call MCP Server---------------------------------

kernel.Plugins.AddFromFunctions("weather", tools.Select(t => t.AsKernelFunction()));
//-----------------------------------------------------------------------------------------------------------

//Enable planning

OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new OpenAIPromptExecutionSettings
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
};

//Create a history store the conversation
var history = new ChatHistory();

string? userInput;

do
{
    Console.Write("User> ");
    userInput = Console.ReadLine();
    if (!string.IsNullOrEmpty(userInput))
    {
        history.AddUserMessage(userInput);

        //Get the response from the AI model.
        //The model will decide if it needs to call any functions from the plugins based on the user input and the conversation history.
        var response = await chatCompletionService.GetChatMessageContentAsync(
            history, 
            executionSettings: openAIPromptExecutionSettings,
            kernel:kernel);

        Console.WriteLine($"Assistant > {response}");
        history.AddMessage(response.Role, response.Content ?? string.Empty);

    }
} while (userInput is not null);