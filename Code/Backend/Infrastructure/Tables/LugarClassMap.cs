using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

public static class LugarClassMap
{
    public static void ConfigureLugarClassMap(this ModelBuilder modelBuilder)
    => modelBuilder.Entity<Lugar>(builder =>
    {
        builder.HasKey(lugar => lugar.Id);
        builder.Property(lugar => lugar.Id)
            .HasColumnName("id");
        builder.ToTable("tb_lugar");

    //================PROPERTIES================
        builder.Property(lugar => lugar.Nome)
            .HasColumnName("nome")
            .IsRequired();

        builder.Property(lugar => lugar.Raio)
            .HasColumnName("raio")
            .IsRequired();

    //================MY-RELATIONS================
        builder.Property(lugar => lugar.GrupoId)
            .HasColumnName("grupo_id")
            .IsRequired();
        builder.HasOne(lugar => lugar.Grupo)
            .WithMany(grupo => grupo.Lugares)
            .HasForeignKey(lugar => lugar.GrupoId);
    });
}