using LaboratoriosCampusTech.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// >>> REGISTRO DEL REPOSITORIO <<<
builder.Services.AddSingleton<IReservationRepository, InMemoryReservationRepository>();

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

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Reservations}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

