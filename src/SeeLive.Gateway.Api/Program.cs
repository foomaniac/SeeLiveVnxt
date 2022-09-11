using SeeLive.Gateway.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Add additional configuration
builder.AddConfiguration();

// Add services to the container.
builder.Services.AddOcelotService(builder.Configuration);
builder.Services.AddControllers();
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
app.MapControllers();
app.AddOcelotMiddleware();

app.Run();
