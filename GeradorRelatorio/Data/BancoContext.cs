using Microsoft.EntityFrameworkCore;

public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options)
        : base(options)
    {
    }

    public DbSet<Relatorio> Relatorios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Relatorio>().HasNoKey(); // Caso o resultado da sua stored procedure não tenha chave primária
    }
}

public class Relatorio
{
    public string NomeRelatorio { get; set; }
    public string NomeBancoDados { get; set; }
    // Adicione outras propriedades conforme necessário
}
