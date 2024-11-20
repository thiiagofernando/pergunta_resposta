using System.ComponentModel.DataAnnotations;
using QuestionarioAPI.Domain.Enums;

namespace QuestionarioAPI.Domain.Entities
{
    public class Pergunta
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Texto { get; set; }
        
        public int SubGrupoId { get; set; }
        public SubGrupo SubGrupo { get; set; }
        public TipoResposta TipoResposta { get; set; }
        public ICollection<OpcaoResposta> OpcoesResposta { get; set; }

        public Pergunta()
        {
            OpcoesResposta = [];
        }
    }
}