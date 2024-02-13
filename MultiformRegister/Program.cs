using Microsoft.EntityFrameworkCore;
using MultiformRegister.DataModel;
using MultiformRegister.InMemoryCache;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RegisterModelDbContext>(options =>
{
	options.UseSqlServer("data source=(local); initial catalog=sample_multistep_form; integrated security=true;");
});
builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddScoped(typeof(IMemoryCache<>), typeof(DistributedMemoryCache<>));
builder.Services.AddScoped<IPersonMemoryCache, PersonMemoryCache>();
builder.Services.AddScoped<IEducationMemoryCache, EducationMemoryCache>();
builder.Services.AddScoped<IAccountMemoryCache, AccountMemoryCache>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseStatusCodePages();
}

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
