using ApiSysGarcom.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.OleDb;

namespace ApiSysGarcom.Context;

public class AppDbContext : DbContext
{

    public DbSet<Produto> Cardapio { get; set; }
    public DbSet<Grupo> GruCard { get; set; }
    public DbSet<Mesa> Mesas { get; set; }
    public DbSet<Garcom> Garcon { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
            
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
        .UseJet($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\SAAB\\BASE\\{BaseNome.NomeBase};")
        .LogTo(Console.WriteLine, LogLevel.Debug);
    }
}

public static class BaseNome
{
    public static string? NomeBase { get; set; } = "CADASTROS.mdb";
}