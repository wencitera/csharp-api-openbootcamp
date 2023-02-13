
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyFirstBackend;
using MyFirstBackend.DataAccess;
using MyFirstBackend.Services;

var builder = WebApplication.CreateBuilder(args);


// 2 Connection with SQL Server Express
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3 Add Context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

// 7 Add Service of JWT Auth
builder.Services.AddJwtTokenServices(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();


// 4 Add Services
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<ICoursesService, CourseService>();
builder.Services.AddScoped<IChaptersService, ChaptersService>();


// 8 Add Auth policy to the project
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User 1"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 9 Config Swagger to take care of JWT Auth
builder.Services.AddSwaggerGen(options =>
{
    // We define the Security for authorization
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
    { 
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization Header using Bearer Scheme"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
             },
            new string[]{}
        }
    });
});

// 5 CORS Configuration
builder.Services.AddCors(options => {
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyMethod();
    });
});

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

// 6 Tell app to use CORS
app.UseCors("CorsPolicy"); 

app.Run();
