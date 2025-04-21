var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TodoDbContext>(opt =>
    opt.UseInMemoryDatabase("Todos"));
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<IGetTodosUseCase, GetTodosInteractor>();
builder.Services.AddScoped<IAddTodoUseCase, AddTodoInteractor>();

builder.Services.AddControllers();
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
