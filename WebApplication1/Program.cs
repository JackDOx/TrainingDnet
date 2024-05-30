using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Training.Data.DBContext;
using Training.Data.Infrastructure.Implementation;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Users;
using Training.Domain.Service.Implementation.User;
using Training.Domain.Service.Interface.User;

var builder = WebApplication.CreateBuilder(args);

AddServices(builder);
// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.Run();

void AddServices(WebApplicationBuilder build) {
    //connect DB SQL
    build.Services.AddDbContext<TrainingDbContext>(options => options.UseSqlServer(build.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
    build.Services.AddScoped<DbContext, TrainingDbContext>();

    // Injections configuration
    build.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    build.Services.AddTransient<IUnitOfWork, UnitOfWork>();

    // Add Service
    build.Services.AddTransient<IUserService, UserService>();

    // Add MediatR
    build.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(CreateUserCommand).Assembly);

    //var assembly = AppDomain.Current.Load("Demo.Domain");
    //services.AddMediatR(assembly);
}
