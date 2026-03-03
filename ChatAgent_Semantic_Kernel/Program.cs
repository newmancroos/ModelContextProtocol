using ChatAgent_Semantic_Kernel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

//Populate values from your OpenAi deployment (Azure AI foundry)
var modelId = "gpt-4o-mini";
var endpoint = "https://api.openai.com/";
var apiKey = "";

//Create a kernel and add the Azure OpenAI chat completion service
//Other than Chat agent there are other Agents too
var builder = Kernel.CreateBuilder()
    .AddOpenAIChatCompletion(modelId, endpoint, apiKey);  //.AddAzureOpenAIChatCompletion(modelId, endpoint, apiKey);

builder.Services.AddLogging(services => services.AddConsole().SetMinimumLevel(LogLevel.Trace));

//Build the kernel
Kernel kernel = builder.Build();    

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

//Add a plugin LightPlugin. Plugins are tools that can be used in the context of a conversation.
//They can be used to extend the capabilities of the model by providing additional functionality.

kernel.Plugins.AddFromType<LightPlugin>("Lights");
kernel.Plugins.AddFromType<WeatherPlugin>("Weather");

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