using Clinica.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Web.Data;

public class DataContext : DbContext
{
    // DEVEMOS CRIAR A TABELA
    public DbSet<Client> Clients { get; set; }    

    public DataContext(DbContextOptions<DataContext> options) : base (options)     // Instalar Package Microsoft.EntityFrameworkCore
    {
         
    }


}
