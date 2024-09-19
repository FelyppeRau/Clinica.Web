using Clinica.Web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(cfg =>
{
    // INSTALAR PACKAGE Microsoft.EntityFrameworkCore.SqlServer     
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<SeedDb>();    // ***** CRIANDO UM SERVI�O *****
                                            // AddTransient: Cria e deita fora. N�o fica em mem�ria
                                            // ***** AddSinglenton: Cria e fica em mem�ria. Fica pra sempre na mem�ria da aplica��o
                                            // ***** AddScope: Cria e j� est� instanciado. Quando criamos outro, apaga o antigo e cria o novo

var app = builder.Build();

RunSeeding(app);

// ***** M�TODO RUN SEEDING *****
// ***** INICIALIZA��O DO SEEDDB *****
static void RunSeeding(IHost host)
{
    var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopeFactory.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetService<SeedDb>();

        seeder.SeedAsync().Wait();
    }
}




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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
