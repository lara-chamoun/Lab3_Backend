var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the LogConsumer as a singleton service
builder.Services.AddSingleton<EventResponse>(sp =>
{
    var queueName = "MyQueue";
    var rabbitMQHostName = "localhost";
    var rabbitMQUserName = "guest";
    var rabbitMQPassword = "guest";

    return new EventResponse(queueName, rabbitMQHostName, rabbitMQUserName, rabbitMQPassword);
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

app.Run();