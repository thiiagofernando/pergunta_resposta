using System.ComponentModel.DataAnnotations;

namespace QuestionarioAPI.Domain.Entities
{
    public class Grupo
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        public ICollection<SubGrupo> SubGrupos { get; set; }

        public Grupo()
        {
            SubGrupos = [];
        }
    }
}