using Application.Commands;
using Application.Handlers;
using Application.IServices;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using WebApplication1;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IRolesService,RolesService >();
builder.Services.AddScoped<ICoursesService,CoursesService >();
builder.Services.AddScoped<IRegisterUserService,RegisterUserService >();
builder.Services.AddScoped<IClassEnrollmentService,ClassEnrollmentService >();
builder.Services.AddScoped<ITeacherCourseEnrollmentService,TeacherCourseEnrollmentService >();

builder.Services.AddTransient<CreatEventHandlerMicroservice>();


builder.Services.AddMediatR(typeof(CreateRoleCommand).Assembly);
builder.Services.AddMediatR(typeof(CreateCourseCommand).Assembly);
builder.Services.AddMediatR(typeof(ClassEnrollmentCommand).Assembly);
builder.Services.AddMediatR(typeof(TeacherCourseEnrollmentCommand).Assembly);



builder.Services.AddHttpClient();
builder.Services.AddScoped<MailService>();


// Add DbContext configuration

//builder.Services.AddDbContext<PostgresContext>(options =>
   //options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<PostgresContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Singleton);

// Configure Firebase Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://securetoken.google.com/fir-loginauth-4bd18";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/fir-loginauth-4bd18",
            ValidateAudience = true,
            ValidAudience = "fir-loginauth-4bd18",
            ValidateLifetime = true
        };
    });


// Add custom authorization handler
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireAuthenticatedUser() // Requires an authenticated user
            .AddRequirements(new RequireRoleRequirement(1))); // Requires the role with value 1 (converted to int)
});

// Add custom authorization handler
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("TeacherPolicy", policy =>
        policy.RequireAuthenticatedUser() // Requires an authenticated user
            .AddRequirements(new RequireRoleRequirement(2))); // Requires the role with value 1 (converted to int)
});

// Add custom authorization handler
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("StudentPolicy", policy =>
        policy.RequireAuthenticatedUser() // Requires an authenticated user
            .AddRequirements(new RequireRoleRequirement(3))); // Requires the role with value 1 (converted to int)
});



builder.Services.AddSingleton<IAuthorizationHandler, RequireRoleHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

