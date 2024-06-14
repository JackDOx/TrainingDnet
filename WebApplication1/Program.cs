using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Training.Authentication.Handlers;
using Training.Authentication.TokenValidators;
using Training.Authentication.Requirements;
using Training.Data.DBContext;
using Training.Data.Infrastructure.Implementation;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Users;
using Training.Domain.Service.Implementation.User;
using Training.Domain.Service.Interface.User;
using Training.Domain.Command.Roles;
using Training.Domain.Service.Implementation.Role;
using Training.Domain.Service.Interface.Role;
using Training.Domain.Command.UserRoles;
using Training.Domain.Service.Implementation.UserRole;
using Training.Domain.Service.Interface.UserRole;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Training.Domain.Service.Implementation.Author;
using Training.Domain.Service.Interface.Author;
using Training.Domain.Service.Interface.Category;
using Training.Domain.Service.Implementation.Category;
using Training.Domain.Service.Interface.Book;
using Training.Domain.Service.Implementation.Book;
using Training.Domain.Service.Interface.ProductRole;
using Training.Domain.Service.Implementation.ProductRole;

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
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Training.API v1"));
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

    //Authen Swagger
    build.Services.Configure<JwtModel>(build.Configuration.GetSection("appJwt"));
    ServiceProvider? servicesProvider = build.Services.BuildServiceProvider();
    var jwtBearerSettings = servicesProvider.GetService<IOptions<JwtModel>>().Value;

    var authenticationBuilder = build.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
    authenticationBuilder.AddJwtBearer(o =>
    {
        // You also need to update /wwwroot/app/scripts/app.js
        o.SecurityTokenValidators.Clear();
        o.SecurityTokenValidators.Add(new JwtBearerValidator());

        var tokenValidationParameters = new TokenValidationParameters();
        tokenValidationParameters.ValidAudience = jwtBearerSettings.Audience;
        tokenValidationParameters.ValidIssuer = jwtBearerSettings.Issuer;
        tokenValidationParameters.IssuerSigningKey = jwtBearerSettings.SigningKey;

        o.TokenValidationParameters = tokenValidationParameters;
        o.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                if (context.Request.Path.ToString()
                    .StartsWith("/HUB/", StringComparison.InvariantCultureIgnoreCase))
                    context.Token = context.Request.Query["access_token"];
                return Task.CompletedTask;
            }
        };
    });

    /*
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o => 
    );
    */

    //Add required authenticated
    build.Services.AddMvc(mvcOptions =>
    {
        ////only allow authenticated users
        var policy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            .AddRequirements(new SolidAccountRequirement())
            .Build();

        mvcOptions.Filters.Add(new AuthorizeFilter(policy));
    });

    //Add Swagger
    build.Services.AddSwaggerGen(c =>
    {
        var jwtSecurityScheme = new OpenApiSecurityScheme
        {
            Scheme = "bearer",
            BearerFormat = "JWT",
            Name = "JWT Authentication",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

            Reference = new OpenApiReference
            {
                Id = JwtBearerDefaults.AuthenticationScheme,
                Type = ReferenceType.SecurityScheme
            }
        };
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "TheCodeBuzz-Service", Version = "v1" });

        c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("RolePolicy", policy =>
        {
            policy.Requirements.Add(new RoleRequirement()); // Custom requirement
        });
    });

    // Authen
    build.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    build.Services.AddScoped<IProfileService, ProfileService>();


    // Requirement handler.
    build.Services.AddScoped<IAuthorizationHandler, SolidAccountRequirementHandler>();
    build.Services.AddScoped<IAuthorizationHandler, RoleRequirementHandler>();

    // Add file program
    build.Services.AddHttpContextAccessor();
    build.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


    // Add Service
    build.Services.AddTransient<IUserService, UserService>();
    build.Services.AddTransient<IRoleService, RoleService>();
    build.Services.AddTransient<IUserRoleService, UserRoleService>();
    build.Services.AddTransient<IAuthorService, AuthorService>();
    build.Services.AddTransient<ICategoryService, CategoryService>();
    build.Services.AddTransient<IBookService, BookService>();
    build.Services.AddTransient<IProductRoleService, ProductRoleService>();

    // Add MediatR
    build.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(CreateUserCommand).Assembly);
    build.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(DeleteUserCommand).Assembly);
    build.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(UpdateUserCommand).Assembly);
    build.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(GetUserPaginationCommand).Assembly);

    //var assembly = AppDomain.Current.Load("Demo.Domain");
    //services.AddMediatR(assembly);
}
