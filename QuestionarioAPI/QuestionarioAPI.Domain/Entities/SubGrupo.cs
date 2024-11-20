using System.ComponentModel.DataAnnotations;

namespace QuestionarioAPI.Domain.Entities
{
    public class SubGrupo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Nome { get; set; }
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
        public ICollection<Pergunta> Perguntas { get; set; }

        public SubGrupo()
        {
            Perguntas = [];
        }
    }
}