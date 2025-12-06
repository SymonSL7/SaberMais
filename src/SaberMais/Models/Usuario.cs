using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SaberMais.Validation;

namespace SaberMais.Models
{
    public class Usuario
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        [SenhaComplexa]
        [StringLength(255)]
        public string Senha { get; set; }
        
        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmarSenha { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório")]
        public Tipo Tipo { get; set; }

        public string? TokenRedefinicaoSenha { get; set; }
        public DateTime? DataExpiracaoToken { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
        public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
        public virtual ICollection<Pergunta> Perguntas { get; set; } = new List<Pergunta>();
        public virtual ICollection<Resposta> Respostas { get; set; } = new List<Resposta>();

    }

    public enum Tipo
    {
        Aluno,
        Instrutor
    }
    
}