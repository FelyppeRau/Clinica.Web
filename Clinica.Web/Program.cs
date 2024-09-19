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

builder.Services.AddTransient<SeedDb>();    // ***** CRIANDO UM SERVIÇO *****
                                            // AddTransient: Cria e deita fora. Não fica em memória
                                            // ***** AddSinglenton: Cria e fica em memória. Fica pra sempre na memória da aplicação
                                            // ***** AddScope: Cria e já está instanciado. Quando criamos outro, apaga o antigo e cria o novo

var app = builder.Build();

RunSeeding(app);

// ***** MÉTODO RUN SEEDING *****
// ***** INICIALIZAÇÃO DO SEEDDB *****
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
