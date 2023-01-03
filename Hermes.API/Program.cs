using Hermes.API.Extensions;
using Hermes.Application.Interfaces.Repos;
using Hermes.Application.Services.BackGroundProcess;
using Hermes.Application.Services.NotificationSender;
using Hermes.Persistence.Contexts;
using Hermes.Persistence.Repositories;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NotifTask API", Version = "v1" });
    c.EnableAnnotations();
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserMessageRepository, UserMessageRepository>();
//

//builder.Services.AddScoped<IMessageRepository, MessageRepository>();

//builder.Services.AddHostedService<WorkerService>();
//builder.Services.AddScoped<WorkerService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPushNotificationProviderService, PushNotificationProviderService>();
//
builder.Services.AddHostedService<SendJobService>();
//builder.Services.AddScoped<SendJobService>();

builder.Services.AddDbContext<AppDbContext>(option =>
                    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
