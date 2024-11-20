using System.ComponentModel.DataAnnotations;

namespace QuestionarioAPI.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Nome { get; set; }
        public List<RespostaUsuario> Respostas { get; set; }

        public Usuario()
        {
            Respostas = [];
        }
    }
}