using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SaberMais.Validation;

namespace SaberMais.Models
{
    public class Resposta
    {
        
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A pergunta é obrigatória")]
        public int PerguntaId { get; set; }

        [ForeignKey("PerguntaId")]
        public virtual Pergunta Pergunta { get; set; } = null!;

        [Required(ErrorMessage = "O usuário é obrigatório")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; } = null!;

        [Required(ErrorMessage = "O conteúdo da resposta é obrigatório")]
        [Column(TypeName = "text")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime Data { get; set; } = DateTime.Now;
        

    }
}
