
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SeeLive.Domain.Seedwork;
using SeeLive.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddMediatR(typeof(Entity).GetTypeInfo().Assembly);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.Authority = "https://localhost:5000";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SeeLive.Api", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "SeeLive.Api");
    });
});

// builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
//{
//    options.Authority = "https://localhost:5000";
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateAudience = false
//    };
//});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SeeLive.Api", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "SeeLive.Api");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
//app.UseAuthorization();
app.MapControllers();
    //.RequireAuthorization("SeeLive.Api");

app.Run();