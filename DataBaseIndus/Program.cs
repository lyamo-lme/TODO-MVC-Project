using ToDoList.GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using ToDoList.Data;

var builder = WebApplication.CreateBuilder(args);

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


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors(x => x
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());

app.UseEndpoints(e =>
{
    e.MapControllers();
});

app.Run();
