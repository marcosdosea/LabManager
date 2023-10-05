using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class LabManagerContext : DbContext
{
    public LabManagerContext()
    {
    }

    public LabManagerContext(DbContextOptions<LabManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atividadeequipamento> Atividadeequipamentos { get; set; }

    public virtual DbSet<Equipamento> Equipamentos { get; set; }

    public virtual DbSet<Instituicao> Instituicaos { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<Setor> Setors { get; set; }

    public virtual DbSet<Software> Softwares { get; set; }

    public virtual DbSet<Softwareequipamento> Softwareequipamentos { get; set; }

    public virtual DbSet<Softwaresala> Softwaresalas { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atividadeequipamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("atividadeequipamento");

            entity.HasIndex(e => e.IdEquipamento, "fk_AtividadeEquipamento_Equipamento1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.IdEquipamento)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idEquipamento");

            entity.HasOne(d => d.IdEquipamentoNavigation).WithMany(p => p.Atividadeequipamentos)
                .HasForeignKey(d => d.IdEquipamento)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_AtividadeEquipamento_Equipamento1");
        });

        modelBuilder.Entity<Equipamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("equipamento");

            entity.HasIndex(e => e.IdSala, "fk_Equipamento_Sala1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.IdSala)
                .HasColumnType("int(11)")
                .HasColumnName("idSala");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Equipamentos)
                .HasForeignKey(d => d.IdSala)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Equipamento_Sala1");
        });

        modelBuilder.Entity<Instituicao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("instituicao");

            entity.HasIndex(e => e.Cnpj, "cnpj_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("ativo");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(50)
                .HasColumnName("cidade");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .HasColumnName("cnpj");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Numero)
                .HasMaxLength(15)
                .HasColumnName("numero");
            entity.Property(e => e.Rua)
                .HasMaxLength(50)
                .HasColumnName("rua");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pessoa");

            entity.HasIndex(e => e.Cpf, "cpd_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdInstituicao, "fk_Pessoa_Instituicao_idx");

            entity.HasIndex(e => e.IdSetor, "fk_Pessoa_Setor1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("ativo");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(50)
                .HasColumnName("cidade");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .HasColumnName("cpf");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.IdInstituicao)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idInstituicao");
            entity.Property(e => e.IdSetor)
                .HasColumnType("int(11)")
                .HasColumnName("idSetor");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Numero)
                .HasMaxLength(15)
                .HasColumnName("numero");
            entity.Property(e => e.Rua)
                .HasMaxLength(50)
                .HasColumnName("rua");

            entity.HasOne(d => d.IdInstituicaoNavigation).WithMany(p => p.Pessoas)
                .HasForeignKey(d => d.IdInstituicao)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Pessoa_Instituicao");

            entity.HasOne(d => d.IdSetorNavigation).WithMany(p => p.Pessoas)
                .HasForeignKey(d => d.IdSetor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Pessoa_Setor1");
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sala");

            entity.HasIndex(e => e.IdSetor, "fk_Sala_Setor1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdSetor)
                .HasColumnType("int(11)")
                .HasColumnName("idSetor");
            entity.Property(e => e.Localizacao)
                .HasMaxLength(50)
                .HasColumnName("localizacao");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdSetorNavigation).WithMany(p => p.Salas)
                .HasForeignKey(d => d.IdSetor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Sala_Setor1");
        });

        modelBuilder.Entity<Setor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("setor");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Software>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("software");

            entity.HasIndex(e => e.IdSetor, "fk_Software_Setor1_idx");

            entity.HasIndex(e => e.Key, "key_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.IdSetor)
                .HasColumnType("int(11)")
                .HasColumnName("idSetor");
            entity.Property(e => e.Key)
                .HasMaxLength(100)
                .HasColumnName("key");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Versao)
                .HasMaxLength(50)
                .HasColumnName("versao");

            entity.HasOne(d => d.IdSetorNavigation).WithMany(p => p.Softwares)
                .HasForeignKey(d => d.IdSetor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Software_Setor1");
        });

        modelBuilder.Entity<Softwareequipamento>(entity =>
        {
            entity.HasKey(e => new { e.IdSoftware, e.IdEquipamento }).HasName("PRIMARY");

            entity.ToTable("softwareequipamento");

            entity.HasIndex(e => e.IdEquipamento, "fk_SoftwareEquipamento_Equipamento1_idx");

            entity.HasIndex(e => e.IdSoftware, "fk_SoftwareEquipamento_Software1_idx");

            entity.Property(e => e.IdSoftware)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idSoftware");
            entity.Property(e => e.IdEquipamento)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idEquipamento");
            entity.Property(e => e.DataAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("dataAtualizacao");

            entity.HasOne(d => d.IdEquipamentoNavigation).WithMany(p => p.Softwareequipamentos)
                .HasForeignKey(d => d.IdEquipamento)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_SoftwareEquipamento_Equipamento1");

            entity.HasOne(d => d.IdSoftwareNavigation).WithMany(p => p.Softwareequipamentos)
                .HasForeignKey(d => d.IdSoftware)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_SoftwareEquipamento_Software1");
        });

        modelBuilder.Entity<Softwaresala>(entity =>
        {
            entity.HasKey(e => new { e.IdSoftware, e.IdSala }).HasName("PRIMARY");

            entity.ToTable("softwaresala");

            entity.HasIndex(e => e.IdSala, "fk_SoftwareSala_Sala1_idx");

            entity.HasIndex(e => e.IdSoftware, "fk_SoftwareSala_Software1_idx");

            entity.Property(e => e.IdSoftware)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("idSoftware");
            entity.Property(e => e.IdSala)
                .HasColumnType("int(11)")
                .HasColumnName("idSala");
            entity.Property(e => e.DataAtualizacao)
                .HasColumnType("datetime")
                .HasColumnName("dataAtualizacao");
            entity.Property(e => e.Solicitante)
                .HasMaxLength(50)
                .HasColumnName("solicitante");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Softwaresalas)
                .HasForeignKey(d => d.IdSala)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_SoftwareSala_Sala1");

            entity.HasOne(d => d.IdSoftwareNavigation).WithMany(p => p.Softwaresalas)
                .HasForeignKey(d => d.IdSoftware)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_SoftwareSala_Software1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
