﻿// <auto-generated />
using System;
using Academico.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Academico.Migrations
{
    [DbContext(typeof(AcademicoContext))]
    [Migration("20231016225117_cursos-disciplinas-cursosDisciplinas")]
    partial class cursosdisciplinascursosDisciplinas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Academico.Models.Curso", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Academico.Models.CursoDisciplina", b =>
                {
                    b.Property<int>("DisciplinaID")
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.HasKey("DisciplinaID", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("CursosDisciplina");
                });

            modelBuilder.Entity("Academico.Models.Departamento", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"), 1L, 1);

                    b.Property<long>("InstituicaoID")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstituicaoID");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Academico.Models.Disciplina", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("Academico.Models.Instituicao", b =>
                {
                    b.Property<long?>("InstituicaoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("InstituicaoID"), 1L, 1);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstituicaoID");

                    b.ToTable("Instituicoes");
                });

            modelBuilder.Entity("Academico.Models.CursoDisciplina", b =>
                {
                    b.HasOne("Academico.Models.Curso", "Curso")
                        .WithMany("CursosDisciplinas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Academico.Models.Disciplina", "Disciplina")
                        .WithMany("CursosDisciplinas")
                        .HasForeignKey("DisciplinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("Academico.Models.Departamento", b =>
                {
                    b.HasOne("Academico.Models.Instituicao", "Instituicao")
                        .WithMany("Departamentos")
                        .HasForeignKey("InstituicaoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("Academico.Models.Curso", b =>
                {
                    b.Navigation("CursosDisciplinas");
                });

            modelBuilder.Entity("Academico.Models.Disciplina", b =>
                {
                    b.Navigation("CursosDisciplinas");
                });

            modelBuilder.Entity("Academico.Models.Instituicao", b =>
                {
                    b.Navigation("Departamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
