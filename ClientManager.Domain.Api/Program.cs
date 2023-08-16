using ClientManager.Domain.Handlers;
using ClientManager.Domain.Infra.Context;
using ClientManager.Domain.Infra.Repositories;
using ClientManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<IClientManagerRepository, ClientManagerRepository>();
builder.Services.AddTransient<ClientHandler, ClientHandler>();
builder.Services.AddTransient<VendorHandler, VendorHandler>();
builder.Services.AddTransient<OrderHandler, OrderHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );

// app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
