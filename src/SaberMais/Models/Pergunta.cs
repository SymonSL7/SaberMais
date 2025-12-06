using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SaberMais.Validation;

namespace SaberMais.Models
{
    public class Pergunta
    {
        
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A aula é obrigatória")]
        public int AulaId { get; set; }

        [ForeignKey("AulaId")]
        public virtual Aula Aula { get; set; } = null!;

        [Required(ErrorMessage = "O usuário é obrigatório")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; } = null!;

        [Required(ErrorMessage = "O conteúdo da pergunta é obrigatório")]
        [Column(TypeName = "text")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime Data { get; set; } = DateTime.Now;

        // Propriedades de navegação
        public virtual ICollection<Resposta> Respostas { get; set; } = new List<Resposta>();

    }
}
