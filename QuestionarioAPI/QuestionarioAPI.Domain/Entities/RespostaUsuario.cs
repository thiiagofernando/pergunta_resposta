using System.ComponentModel.DataAnnotations;

namespace QuestionarioAPI.Domain.Entities
{
    public class RespostaUsuario
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario{ get; set; }
        public int PerguntaId { get; set; }
        public Pergunta Pergunta { get; set; }
        [Required]
        [MaxLength(1000)]
        public string RespostaTexto { get; set; }
        public int? OpcaoRespostaId { get; set; }
        public OpcaoResposta? OpcaoResposta { get; set; }

        [MaxLength(5000)]
        public string UrlFoto { get; set; }
        public DateTime DataResposta { get; set; }
        public RespostaUsuario()
        {
            DataResposta = DateTime.Now;
        }
    }
}