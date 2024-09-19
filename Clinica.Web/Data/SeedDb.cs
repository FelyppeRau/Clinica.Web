using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Clinica.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Web.Data;

public class SeedDb
{
    private readonly DataContext _context;
    private Random _random; 

    public SeedDb(DataContext context)
    {
        _context = context;
        _random = new Random();
    }

    public async Task SeedAsync()
    {
        //await _context.Database.EnsureCreatedAsync(); // NÃO CRIA OS MIGRATIONS
        await _context.Database.MigrateAsync();   // CRIA OS MIGRATIONS AO CORRER O SEED

        if(!_context.Clients.Any())
        {
            AddClients("Nuno Vilhena Santos","123456789", /* nuno@yopmail.com, 123456789, DateTime.ParseExact("01/01/1985", "dd/MM/yyyy", CultureInfo.InvariantCulture),*/ "Beja");
            AddClients("Pedro Pinto", "123456789", /* nuno@yopmail.com, 123456789, DateTime.ParseExact("01/01/1985", "dd/MM/yyyy", CultureInfo.InvariantCulture),*/ "Beja");
            AddClients("Filipa Martins Santos", "123456789", /* nuno@yopmail.com, 123456789, DateTime.ParseExact("01/01/1985", "dd/MM/yyyy", CultureInfo.InvariantCulture),*/ "Beja");
            AddClients("Mafalda Andrade", "123456789", /* nuno@yopmail.com, 123456789, DateTime.ParseExact("01/01/1985", "dd/MM/yyyy", CultureInfo.InvariantCulture),*/ "Beja");
            AddClients("Carlos Silva", "123456789", /* nuno@yopmail.com, 123456789, DateTime.ParseExact("01/01/1985", "dd/MM/yyyy", CultureInfo.InvariantCulture),*/ "Beja");
            AddClients("Sara Nunes Almeida", "123456789", /* nuno@yopmail.com, 123456789, DateTime.ParseExact("01/01/1985", "dd/MM/yyyy", CultureInfo.InvariantCulture),*/ "Beja");
            AddClients("Maria Joana Aguiar", "123456789", /* nuno@yopmail.com, 123456789, DateTime.ParseExact("01/01/1985", "dd/MM/yyyy", CultureInfo.InvariantCulture),*/ "Beja");
              
        }

        await _context.SaveChangesAsync();
    }

    
    private void AddClients(string name, string bi, /*string email, string phone, DateTime birth,*/ string address)    //*** COMO COLOCAR A FOTO COMO PARÂMETRO
    {
        // ***** A classe Regex (expressões regulares) pode ser usada para remover todos os tipos de espaços em branco,
        // incluindo espaços, tabulações (\t), quebras de linha (\n, \r) etc *****.
        var email = /*Regex.Replace(*/name.ToLower().Trim()/*, @"\s+", "")*/ + "@yopmail.com";      
        var phone = "9" + _random.Next(99999999).ToString("D8");

        // GERAÇÃO DIRETA DE UMA DATA ALEATORIA ENTRE 01/01/1950 ATÉ HOJE
        DateTime startDate = new DateTime(1900,1,1);
        int range = (DateTime.Today - startDate).Days;   // Calcula o intervalo em dias        
        DateTime birth = startDate.AddDays(_random.Next(range));   // Gera uma data aleatória

        _context.Clients.Add(new Client
        {
            Name = name,
            BI = bi,
            Email = email,
            Phone = phone,
            Birth = birth,
            Address = address,

        });

        
    }
}
