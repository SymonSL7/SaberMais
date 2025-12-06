using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SaberMais.Validation;

namespace SaberMais.Models
{
    public class AlterarSenhaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A senha atual é obrigatória.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "A nova senha é obrigatória.")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        [SenhaComplexa]
        public string NovaSenha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Nova Senha")]
        [Compare("NovaSenha", ErrorMessage = "A nova senha e a confirmação não conferem.")]
        public string ConfirmarNovaSenha { get; set; } 
    }
}