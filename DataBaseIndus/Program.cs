using DataBaseIndus.GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using ToDoList.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<CategoryRepositoryXML>();
builder.Services.AddTransient<TaskRepositoryXML>();
builder.Services.AddTransient<TaskRepository>();
builder.Services.AddTransient<CategoryRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<DataSchema>();
builder.Services
    .AddGraphQL(options =>
    {
        options.EnableMetrics = true;})
    .AddSystemTextJson()
    .AddGraphTypes(typeof(DataSchema));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseGraphQL<DataSchema>();
app.UseGraphQLAltair();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=List}/{action=Index}/{id?}");

app.Run();
