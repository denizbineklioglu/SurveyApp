using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Context;
using SurveyApp.Infrastructure.Repositories;
using SurveyApp.Services;
using SurveyApp.Services.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddScoped<ISurveyService, SurveyService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IOptionService, OptionService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();


builder.Services.AddScoped<ISurveyRepository, EFSurveyRepository>();
builder.Services.AddScoped<IQuestionRepository, EFQuestionRepository>();
builder.Services.AddScoped<IOptionRepository, EFOptionRepository>();
builder.Services.AddScoped<IAnswerRepository, EFAnswerRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapProfile));



var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<SurveyAppContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SurveyAppContext>();

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
