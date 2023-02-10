
using Microsoft.EntityFrameworkCore;
using MyFirstBackend.DataAccess;
using MyFirstBackend.Services;

var builder = WebApplication.CreateBuilder(args);


// 2 Connection with SQL Server Express
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3 Add Context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

// 7 Add Service of JWT Auth
//builder.Services.addjwttokenservice(builder.Configuration)

// Add services to the container.
builder.Services.AddControllers();


// 4 Add Services
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<ICoursesService, CourseService>();
builder.Services.AddScoped<IChaptersService, ChaptersService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 8 Config Swagger to take care of JWT Auth
builder.Services.AddSwaggerGen();

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
