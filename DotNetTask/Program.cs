using DotNetTask.Core;
using DotNetTask.Repository;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var configuration = builder.Configuration;
builder.Services.AddSingleton((provider) =>
{
    var endpointUri = configuration["CosmosDbSetting:EndpointUri"];
    var primaryKey = configuration["CosmosDbSetting:PrimaryKey"];
    var database = configuration["CosmosDbSetting:Database"];
    var cosmosClientOption = new CosmosClientOptions
    {
        ApplicationName = database,
        HttpClientFactory = () =>
        {
            HttpMessageHandler httpMessageHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (req, cert, chain, errors) => true
            };

            return new HttpClient(httpMessageHandler);
        },
        ConnectionMode = ConnectionMode.Gateway,
        LimitToEndpoint = true
    };

    var logger = LoggerFactory.Create(builder => { builder.AddConsole(); });
    var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOption);
    var db = cosmosClient.CreateDatabaseIfNotExistsAsync(database).Result;
     db.Database.CreateContainerIfNotExistsAsync("Program", "/id", 400);
     db.Database.CreateContainerIfNotExistsAsync("Application", "/id", 400);
    cosmosClient.ClientOptions.ConnectionMode = ConnectionMode.Direct;
    return cosmosClient;

});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IProgramService, ProgramService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
