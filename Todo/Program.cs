using Todo.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

app.Run();
