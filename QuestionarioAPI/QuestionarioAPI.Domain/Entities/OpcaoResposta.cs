using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionarioAPI.Domain.Entities
{
    public class OpcaoResposta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Texto { get; set; }
        public int PerguntaId { get; set; }
        public Pergunta Pergunta {get;set;}
    }
}