using UsersAPI.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();

var app = builder.Build();

app.UseSwaggerDoc();
app.UseAuthorization();
app.MapControllers();
app.Run();
