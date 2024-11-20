using Microsoft.EntityFrameworkCore;
using QuestionarioAPI.Domain.Entities;

namespace QuestionarioAPI.Infrastructure.Data
{
    public class QuestionarioContext : DbContext
    {
        public QuestionarioContext(DbContextOptions<QuestionarioContext> options)
    : base(options)
        {
        }

        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<SubGrupo> SubGrupos { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<OpcaoResposta> OpcoesResposta { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RespostaUsuario> RespostasUsuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração Grupo -> SubGrupo (1:N)
            modelBuilder.Entity<Grupo>()
                .HasMany(g => g.SubGrupos)
                .WithOne(s => s.Grupo)
                .HasForeignKey(s => s.GrupoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração SubGrupo -> Pergunta (1:N)
            modelBuilder.Entity<SubGrupo>()
                .HasMany(s => s.Perguntas)
                .WithOne(p => p.SubGrupo)
                .HasForeignKey(p => p.SubGrupoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração Pergunta -> OpcaoResposta (1:N)
            modelBuilder.Entity<Pergunta>()
                .HasMany(p => p.OpcoesResposta)
                .WithOne(o => o.Pergunta)
                .HasForeignKey(o => o.PerguntaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração Usuario -> RespostaUsuario (1:N)
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Respostas)
                .WithOne(r => r.Usuario)
                .HasForeignKey(r => r.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração RespostaUsuario -> Pergunta (N:1)
            modelBuilder.Entity<RespostaUsuario>()
                .HasOne(r => r.Pergunta)
                .WithMany()
                .HasForeignKey(r => r.PerguntaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração RespostaUsuario -> OpcaoResposta (N:1)
            modelBuilder.Entity<RespostaUsuario>()
                .HasOne(r => r.OpcaoResposta)
                .WithMany()
                .HasForeignKey(r => r.OpcaoRespostaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false); 

            // Configurações adicionais de propriedades
            modelBuilder.Entity<RespostaUsuario>()
                .Property(r => r.DataResposta)
                .HasDefaultValueSql("DATETIME('now')"); // Para SQLite
                                                        // Se estiver usando SQL Server, use: .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<RespostaUsuario>()
                .Property(r => r.UrlFoto)
                .IsRequired(false);

            // Índices para melhor performance
            modelBuilder.Entity<SubGrupo>()
                .HasIndex(s => s.GrupoId);

            modelBuilder.Entity<Pergunta>()
                .HasIndex(p => p.SubGrupoId);

            modelBuilder.Entity<OpcaoResposta>()
                .HasIndex(o => o.PerguntaId);

            modelBuilder.Entity<RespostaUsuario>()
                .HasIndex(r => r.UsuarioId);

            modelBuilder.Entity<RespostaUsuario>()
                .HasIndex(r => r.PerguntaId);

            modelBuilder.Entity<RespostaUsuario>()
                .HasIndex(r => r.OpcaoRespostaId);
        }
    }
}