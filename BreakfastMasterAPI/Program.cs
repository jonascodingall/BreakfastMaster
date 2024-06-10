using AutoMapper;
using BreakfastMasterAPI.Data;
using BreakfastMasterAPI.MapperProfiles;
using BreakfastMasterAPI.Models;
using BreakfastMasterAPI.Repositories;
using BreakfastMasterAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// efcore
builder.Services.AddDbContext<DataContext>(options =>
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseLazyLoadingProxies()
    );

// dependencie incjection
builder.Services.AddScoped<IRepositoryAsync<UserModel>, RepositoryAsync<DataContext ,UserModel>>();
builder.Services.AddScoped<IRepositoryAsync<GroupModel>, RepositoryAsync<DataContext , GroupModel>>();
builder.Services.AddScoped<IRepositoryAsync<BreadRollModel>, RepositoryAsync<DataContext , BreadRollModel>>();
builder.Services.AddScoped<IRepositoryAsync<UserBreadRollModel>, RepositoryAsync<DataContext , UserBreadRollModel>>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IBreadRollService, BreadRollService>();

// automapper
builder.Services.AddAutoMapper(typeof(BreadRollMapperProfile));
builder.Services.AddAutoMapper(typeof(UserMapperProfile));
builder.Services.AddAutoMapper(typeof(GroupMapperProfile));


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
