using EcommerceServiceOperation.Infrastructure.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseLayer(builder.Configuration);
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddGrpcServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.MapGrpcServices();
app.Run();