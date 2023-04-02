var builder = WebApplication.CreateBuilder(args);

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

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Category}/{action=CategoryPrice}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}");    //Routing - at least one configuration, this defines the URL pattern in the browser.

app.Run();


/*
In order to show something in the output in the URL

1.Put the name of the controller in the pattern: "{controller: ..." 
2.After that you add /methodName
*/

