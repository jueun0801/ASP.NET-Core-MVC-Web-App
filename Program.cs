using Assignment_12._1.Models;
using Assignment_12._1.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<ICRUD, ProductRepository>();  //Step 4. Register services then add link in layout.cshtml
builder.Services.AddScoped<ICRUD, DBCRUDRepository>();   //7. register db service
builder.Services.AddScoped<IFileUploadService, FileUploadService>();    //registering file upload service
//builder.Services.AddDbContext<ProductContext>(options => options.UseSqlite("Data Source = Productsdb.db"));  //8. register DbContext //Sqlite is 1 way to store data

builder.Services.AddIdentity<User, IdentityRole>(options =>//STEP 3. ADD SERVICES FOR IDENTITY(this is the login feature)
{
    options.Lockout.MaxFailedAccessAttempts = 10;   //Add login functionalities as needed
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<UserContext>();
//STEP 4. CONNECT TO DATABASE (SQlite or SQLServer)
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer("Server=DESKTOP-I6NRMKT;Database=PCAD7MVCProdUser;Trusted_Connection=true;MultipleActiveResultSets=True"));

builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer("Server=DESKTOP-I6NRMKT;Database=PCAD7MVCProduct;Trusted_Connection=true;MultipleActiveResultSets=True"));
var app = builder.Build();

//app.Services.GetService<ProductContext>().Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProductContext>();
    dbContext.Database.EnsureCreated();
    var userdbContext = scope.ServiceProvider.GetRequiredService<UserContext>();    //STEP 5. ENSURE DB IS GETTING CREATED IN SCOPE
    userdbContext.Database.EnsureCreated();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();//STEP 6. Add UseAuthentication before Use Authorization (this checks for the correct user)
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
