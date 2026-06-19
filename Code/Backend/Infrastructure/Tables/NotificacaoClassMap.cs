using Microsoft.EntityFrameworkCore;

public static class NotificacaoClassMap
{
    public static void ConfigureNotificacaoClassMap(this ModelBuilder modelBuilder)
    => modelBuilder.Entity<Notificacao>(builder =>
    {
        builder.HasKey(notificacao => notificacao.Id);
        builder.Property(notificacao => notificacao.Id)
            .HasColumnName("id");
        builder.ToTable("tb_notificacao");

    //================PROPERTIES================
        builder.Property(notificacao => notificacao.Mensagem)
            .HasColumnName("mensagem")
            .IsRequired();

    //================MY-RELATIONS================
        builder.Property(notificacao => notificacao.IdDestinatario)
            .HasColumnName("destinatario_id")
            .IsRequired();
        builder.HasOne(notificacao => notificacao.Destinatario)
            .WithMany(destinatario => destinatario.NotificacoesRecebidas)
            .HasForeignKey(notificacao => notificacao.IdDestinatario);

        builder.Property(notificacao => notificacao.IdRemetente)
            .HasColumnName("remetente_id")
            .IsRequired();
        builder.HasOne(notificacao => notificacao.Remetente)
            .WithMany(remetente => remetente.NotificacoesEnviadas)
            .HasForeignKey(notificacao => notificacao.IdRemetente);
    });
}