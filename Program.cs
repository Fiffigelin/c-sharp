using c_sharp.Contracts;
using c_sharp.Data;
using c_sharp.Repositories;
using c_sharp.Service.UserService;
using Microsoft.EntityFrameworkCore;
// using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Web api", Version = "v1" });
});

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite("Data Source=localDB.db"));
builder.Services.AddScoped<IUserContract, UserRepository>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.RoutePrefix = "";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web api v1");
    });
}
// app.UseCors(policy =>
//     policy.WithOrigins("http://localhost:5152")
//     .AllowAnyMethod()
//     .WithHeaders(HeaderNames.ContentType)
//     );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
