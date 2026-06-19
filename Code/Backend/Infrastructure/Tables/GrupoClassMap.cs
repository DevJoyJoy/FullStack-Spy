using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

public static class GrupoClassMap
{
    public static void ConfigureGrupoClassMap(this ModelBuilder modelBuilder)
    => modelBuilder.Entity<Grupo>(builder =>
    {
        builder.HasKey(grupo => grupo.Id);
        builder.Property(grupo => grupo.Id)
            .HasColumnName("id");
        builder.ToTable("tb_grupo");

    //================PROPERTIES================
        builder.Property(grupo => grupo.Nome)
            .HasColumnName("nome")
            .IsRequired();

        builder.Property(grupo => grupo.Link)
            .HasColumnName("link")
            .IsRequired();

    //================RELATIONS================
        builder.HasMany(grupo => grupo.Usuarios)
            .WithMany(usuario => usuario.Grupos)
            .UsingEntity(
                "tb_usuario_grupo",
                r => r.HasOne(typeof(Usuario)).WithMany().HasForeignKey("usuario_id").HasPrincipalKey(nameof(Usuario.Id)),
                l => l.HasOne(typeof(Grupo)).WithMany().HasForeignKey("grupo_id").HasPrincipalKey(nameof(Grupo.Id)),
                j => j.HasKey("usuario_id", "grupo_id")
            );
        
        builder.HasMany(grupo => grupo.Lugares)
            .WithOne(lugar => lugar.Grupo)
            .HasForeignKey(lugar => lugar.GrupoId);
    });
}