using EcommerceServiceOperation.Infrastructure.Extension;
using EcommerceServiceOperation.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpcServices();

var app = builder.Build();

app.MapGrpcServices();

// app.MapGrpcService<PaymentServiceImpl>();

app.Run();