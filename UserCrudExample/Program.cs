using UserCrudExample.Services;

var builder = WebApplication.CreateBuilder(args);

// اضافه کردن سرویس gRPC
builder.Services.AddGrpc();

var app = builder.Build();

// مپ کردن سرویس UserService
app.MapGrpcService<UserService>();

app.MapGet("/", () => "gRPC server is running!");

app.Run();