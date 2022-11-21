using AutoMapper;
using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;
using HeadhuntersCandidatesDatabase.Mappers;
using HeadhuntersCandidatesDatabase.Services;
using HeadhuntersCandidatesDatabase.Services.Validations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("HeadhuntersCandidatesDatabase");

builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<IDbService, DbService>();

builder.Services.AddScoped<IEntityService<Candidate>, EntityService<Candidate>>();
builder.Services.AddScoped<IEntityService<Company>, EntityService<Company>>();
builder.Services.AddScoped<IEntityService<Position>, EntityService<Position>>();
builder.Services.AddScoped<IEntityService<Skill>, EntityService<Skill>>();
builder.Services.AddScoped<IEntityService<CandidateSkillset>, EntityService<CandidateSkillset>>();
builder.Services.AddScoped<IEntityService<CompanyPositions>, EntityService<CompanyPositions>>();
builder.Services.AddScoped<IEntityService<PositionSkills>, EntityService<PositionSkills>>();

builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<ICandidateSkillsetService, CandidateSkillsetService>();
builder.Services.AddScoped<ICompanyPositionsService, CompanyPositionsService>();
builder.Services.AddScoped<IPositionSkillsService, PositionSkillsService>();

builder.Services.AddScoped<IValidator, Validator>();

builder.Services.AddSingleton<IMapper>(AutoMapperConfig.CreateMapper());

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
