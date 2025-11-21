var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddAzureSqlServer("sql")
    .RunAsContainer();

var sqlDB = sqlServer.AddDatabase("userdb");

var apiService = builder
    .AddProject<Projects.UserApp_ApiService>("userapi")
    .WithReference(sqlDB);

builder.AddProject<Projects.UserApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();