var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMcpServer()
    .WithHttpTransport()   //stdio is another Trabsport option
    .WithToolsFromAssembly();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.MapMcp();
app.Run();

