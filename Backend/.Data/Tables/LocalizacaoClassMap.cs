using Microsoft.EntityFrameworkCore;

public static class LocalizacaoClassMap
{
    public static void ConfigureLocalizacaoClassMap(this ModelBuilder modelBuilder)
    => modelBuilder.Entity<Localizacao>(builder =>
    {
        builder.HasKey(localizacao => localizacao.Id);
        builder.Property(localizacao => localizacao.Id)
            .HasColumnName("id");
        builder.ToTable("tb_localizacao");

    //================PROPERTIES================
        builder.Property(Localizacao => Localizacao.Latitude)
            .HasColumnName("latitude")
            .IsRequired();
        builder.Property(Localizacao => Localizacao.Longitude)
            .HasColumnName("longitude")
            .IsRequired();
        builder.Property(Localizacao => Localizacao.Data)
            .HasColumnName("data")
            .IsRequired();

    //================MY-RELATIONS================
        builder.Property(localizacao => localizacao.UsuarioId)
            .HasColumnName("usuario_id")
            .IsRequired();
        builder.HasOne(localizacao => localizacao.Usuario)
            .WithMany(usuario => usuario.Localizacoes)
            .HasForeignKey(localizacao => localizacao.UsuarioId);
    });
}