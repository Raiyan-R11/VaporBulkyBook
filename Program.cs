
using BulkyBookWeb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
//builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//  ^UNCOMMENT INCASE ADDITIONS TO HTML IN VIEWS DO NOT GET APPLIED 

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

// Configure the HTTP request pipeline.<--------order matters in pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();//use static files in wwwroot

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(//route to controller and action
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// M: class in c#. represents data transferred between V and C. represent a table in a db.
// V: interface. html css. 
// C: interface between M and V. recieves the request from user, user->C->M->C->V->C->user