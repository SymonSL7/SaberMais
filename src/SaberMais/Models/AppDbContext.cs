using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SaberMais.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Curso> Cursos { get; set; }    
        
        public DbSet<Matricula> Matriculas { get; set; }
        
        public DbSet<Aula> Aulas { get; set; }
        
        public DbSet<Pergunta> Perguntas { get; set; }

        public DbSet<Resposta> Respostas { get; set; }

        public DbSet<AulaConcluida> AulaConcluidas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Matricula>(entity =>
            {

                entity.HasOne(m => m.Usuario)
                    .WithMany(u => u.Matriculas)
                    .HasForeignKey(m => m.UsuarioId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(m => m.Curso)
                    .WithMany(c => c.Matriculas)
                    .HasForeignKey(m => m.CursoId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Pergunta>(entity =>
            {

                entity.HasOne(p => p.Aula)
                    .WithMany(a => a.Perguntas)
                    .HasForeignKey(p => p.AulaId)
                    .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(p => p.Usuario)
                    .WithMany(u => u.Perguntas)
                    .HasForeignKey(p => p.UsuarioId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            
            modelBuilder.Entity<Resposta>(entity =>
            {
                
                entity.HasOne(r => r.Pergunta)
                    .WithMany(p => p.Respostas)
                    .HasForeignKey(r => r.PerguntaId)
                    .OnDelete(DeleteBehavior.Cascade);

                
                entity.HasOne(r => r.Usuario)
                    .WithMany(u => u.Respostas)
                    .HasForeignKey(r => r.UsuarioId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<AulaConcluida>()
                .HasIndex(ac => new { ac.AulaId, ac.MatriculaId })
                .IsUnique();

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Curso)
                .WithMany(c => c.Matriculas)
                .HasForeignKey(m => m.CursoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AulaConcluida>()
                .HasOne(ac => ac.Matricula)
                .WithMany(m => m.AulasConcluidas) // Se não tiver a lista na Matricula, use .WithMany() vazio
                .HasForeignKey(ac => ac.MatriculaId)
                .OnDelete(DeleteBehavior.Restrict);

        }  

    }
}