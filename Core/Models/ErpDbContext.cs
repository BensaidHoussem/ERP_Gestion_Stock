using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core.Models;

public partial class ErpDbContext : DbContext
{
    public ErpDbContext()
    {
    }

    public ErpDbContext(DbContextOptions<ErpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Commande> Commandes { get; set; }

    public virtual DbSet<Fouarticle> Fouarticles { get; set; }

    public virtual DbSet<Fournisseur> Fournisseurs { get; set; }

    public virtual DbSet<Listarticle> Listarticles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=ERP;Username=postgres;Password=97919170");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Codeart).HasName("article_pkey");

            entity.ToTable("article");

            entity.Property(e => e.Codeart)
                .HasColumnType("character varying")
                .HasColumnName("codeart");
            entity.Property(e => e.Libelle)
                .HasMaxLength(20)
                .HasColumnName("libelle");
            entity.Property(e => e.Prix)
                .HasPrecision(15, 3)
                .HasColumnName("prix");
            entity.Property(e => e.Qte).HasColumnName("qte");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Codeclient).HasName("client_pkey");

            entity.ToTable("client");

            entity.Property(e => e.Codeclient)
                .HasColumnType("character varying")
                .HasColumnName("codeclient");
            entity.Property(e => e.Adresse)
                .HasMaxLength(30)
                .HasColumnName("adresse");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasColumnName("email");
            entity.Property(e => e.Nom)
                .HasMaxLength(20)
                .HasColumnName("nom");
            entity.Property(e => e.Tel)
                .HasMaxLength(8)
                .HasColumnName("tel");
        });

        modelBuilder.Entity<Commande>(entity =>
        {
            entity.HasKey(e => e.Numcmd).HasName("commande_pkey");

            entity.ToTable("commande");

            entity.Property(e => e.Numcmd)
                .HasColumnType("character varying")
                .HasColumnName("numcmd");
            entity.Property(e => e.Codeclient)
                .HasMaxLength(30)
                .HasColumnName("codeclient");
            entity.Property(e => e.Datecmd).HasColumnName("datecmd");
            entity.Property(e => e.Prix)
                .HasPrecision(15, 3)
                .HasColumnName("prix");
            entity.Property(e => e.Prixttc)
                .HasPrecision(15, 3)
                .HasColumnName("prixttc");
            entity.Property(e => e.Tva)
                .HasPrecision(15, 3)
                .HasColumnName("tva");

            entity.HasOne(d => d.CodeclientNavigation).WithMany(p => p.Commandes)
                .HasForeignKey(d => d.Codeclient)
                .HasConstraintName("cmdclient_fk");
        });

        modelBuilder.Entity<Fouarticle>(entity =>
        {
            entity.HasKey(e => new { e.Codefour, e.Codeart }).HasName("fouarticle_pk");

            entity.ToTable("fouarticle");

            entity.Property(e => e.Codefour)
                .HasColumnType("character varying")
                .HasColumnName("codefour");
            entity.Property(e => e.Codeart)
                .HasColumnType("character varying")
                .HasColumnName("codeart");
            entity.Property(e => e.Prixht)
                .HasPrecision(15, 3)
                .HasColumnName("prixht");
            entity.Property(e => e.Qte).HasColumnName("qte");

            entity.HasOne(d => d.CodeartNavigation).WithMany(p => p.Fouarticles)
                .HasForeignKey(d => d.Codeart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("codeart_fk");

            entity.HasOne(d => d.CodefourNavigation).WithMany(p => p.Fouarticles)
                .HasForeignKey(d => d.Codefour)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("codefour_fk");
        });

        modelBuilder.Entity<Fournisseur>(entity =>
        {
            entity.HasKey(e => e.Codefour).HasName("fournisseur_pkey");

            entity.ToTable("fournisseur");

            entity.Property(e => e.Codefour)
                .HasColumnType("character varying")
                .HasColumnName("codefour");
            entity.Property(e => e.Adresse)
                .HasMaxLength(20)
                .HasColumnName("adresse");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasColumnName("email");
            entity.Property(e => e.Nom)
                .HasMaxLength(20)
                .HasColumnName("nom");
            entity.Property(e => e.Tel)
                .HasMaxLength(20)
                .HasColumnName("tel");
        });

        modelBuilder.Entity<Listarticle>(entity =>
        {
            entity.HasKey(e => new { e.Numcmd, e.Codeart }).HasName("pk_listarticle");

            entity.ToTable("listarticle");

            entity.Property(e => e.Numcmd)
                .HasColumnType("character varying")
                .HasColumnName("numcmd");
            entity.Property(e => e.Codeart)
                .HasColumnType("character varying")
                .HasColumnName("codeart");
            entity.Property(e => e.Prixht)
                .HasPrecision(15, 3)
                .HasColumnName("prixht");
            entity.Property(e => e.Qte).HasColumnName("qte");

            entity.HasOne(d => d.CodeartNavigation).WithMany(p => p.Listarticles)
                .HasForeignKey(d => d.Codeart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("codeart_fk");

            entity.HasOne(d => d.NumcmdNavigation).WithMany(p => p.Listarticles)
                .HasForeignKey(d => d.Numcmd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("numcmd_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
