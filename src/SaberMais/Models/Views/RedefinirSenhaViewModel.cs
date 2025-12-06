using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SaberMais.Validation;

namespace SaberMais.Models
{
    public class RedefinirSenhaViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }


        // --- Campos visíveis para o usuário ---

        [Required(ErrorMessage = "O campo 'Nova Senha' é obrigatório.")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        [SenhaComplexa]
        [Display(Name = "Nova Senha")]
        public string NovaSenha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a nova senha")]
        [Compare("NovaSenha", ErrorMessage = "A nova senha e a senha de confirmação não coincidem.")]
        public string ConfirmarNovaSenha { get; set; }
        
    }
}