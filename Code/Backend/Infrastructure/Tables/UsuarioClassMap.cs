using Microsoft.EntityFrameworkCore;

public static class UsuarioClassMap
{
    public static void ConfigureUsuarioClassMap(this ModelBuilder modelBuilder)
    => modelBuilder.Entity<Usuario>(builder =>
    {
        builder.HasKey(usuario => usuario.Id);
        builder.Property(usuario => usuario.Id)
            .HasColumnName("id");
        builder.ToTable("tb_usuario");

    //================PROPERTIES================
        builder.Property(usuario => usuario.Nome)
            .HasColumnName("nome")
            .IsRequired();
        
        builder.Property(usuario => usuario.Icon)
            .HasColumnName("icon")
            .IsRequired();

    //================RELATIONS================
        builder.HasMany(usuario => usuario.Grupos)
            .WithMany(grupo => grupo.Usuarios)
            .UsingEntity(
                "tb_usuario_grupo",
                r => r.HasOne(typeof(Grupo)).WithMany().HasForeignKey("grupo_id").HasPrincipalKey(nameof(Grupo.Id)),
                l => l.HasOne(typeof(Usuario)).WithMany().HasForeignKey("usuario_id").HasPrincipalKey(nameof(Usuario.Id)),
                j => j.HasKey("grupo_id","usuario_id")
            );

        builder.HasMany(usuario => usuario.Localizacoes)
            .WithOne(localizacao => localizacao.Usuario)
            .HasForeignKey(localizacao => localizacao.UsuarioId);

        builder.HasMany(usuario => usuario.Notificacoes)
            .WithOne(notificacao => notificacao.Destinatario)
            .HasForeignKey(notificacao => notificacao.IdDestinatario);
        
        builder.HasMany(usuario => usuario.Notificacoes)
            .WithOne(notificacao => notificacao.Remetente)
            .HasForeignKey(notificacao => notificacao.IdRemetente);
        
    });
}