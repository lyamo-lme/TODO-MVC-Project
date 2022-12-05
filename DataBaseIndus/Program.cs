using ToDoList.Data;

var builder = WebApplication.CreateBuilder(args);

string connectionString =
    $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Directory.GetCurrentDirectory()
                                                            + @"\Data\Todo.mdf"}" + @";Integrated Security=True;";
builder.Configuration["ConnectionStrings"] = connectionString;

Console.WriteLine(builder.Configuration["ConnectionStrings"]);
builder.Services.AddTransient<ITodoRepository,TodoRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddControllers();

builder.Services.AddCors(
    builder => {
        builder.AddDefaultPolicy(option =>
        {
            option.AllowAnyOrigin();
            option.AllowAnyMethod();
            option.AllowAnyHeader();
        });
    }
    );

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.MapControllers();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors(x => x
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());

app.Run();
