using DataBaseIndus.Data;
using ToDoList.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CategoryRepositoryXML>();
builder.Services.AddTransient<TaskRepositoryXML>();
builder.Services.AddTransient<TaskRepository>();
builder.Services.AddTransient<CategoryRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=List}/{action=Index}/{id?}");

app.Run();
