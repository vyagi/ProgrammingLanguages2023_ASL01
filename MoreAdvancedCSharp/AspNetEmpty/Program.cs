var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
// app.MapGet("/", () => "Hello World from the ASP.NET App!");
// app.MapGet("/hello", () => "A new route was added which responds to hello");

app.MapControllerRoute(name: "default" , pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
