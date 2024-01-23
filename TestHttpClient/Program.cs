using Microsoft.AspNetCore.Hosting;
using Posts.Business.Services;
using Posts.DataContract.Interfaces;
using TestHttpClient;
using TestHttpClient.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IGetAllUsers, GetAllUsers>();
builder.Services.AddScoped<IGetPosts, GetPosts>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});
//void ConfigureServices(IServiceCollection services)
//{
//    // Other configurations...

//    // Add AutoMapper
//    services.AddAutoMapper(typeof(MappingConfiguration));

//    // Add the global exception filter
//    services.AddControllers(options =>
//    {
//        options.Filters.Add<GlobalExceptionFilter>();
//    });
//}


//builder.Services.AddHttpClient("ById", ById =>
//{
//    ById.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
