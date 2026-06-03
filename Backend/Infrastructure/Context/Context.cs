using Microsoft.EntityFrameworkCore;

public class Context(DbContextOptions<Context> ctx) : DbContext(ctx)
{
    public DbSet<Grupo> Grupos {get;set;}
    public DbSet<Localizacao> Localizacoes {get;set;}
    public DbSet<Lugar> Lugares {get;set;}
    public DbSet<Usuario> Usuarios {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureGrupoClassMap();
        modelBuilder.ConfigureLocalizacaoClassMap();
        modelBuilder.ConfigureLugarClassMap();
        modelBuilder.ConfigureUsuarioClassMap();
        // modelBuilder.Configur(); 

        base.OnModelCreating(modelBuilder);
    }
}