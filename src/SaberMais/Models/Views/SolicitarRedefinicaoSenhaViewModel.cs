using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaberMais.Models
{
    public class SolicitarRedefinicaoSenhaViewModel
    {
        
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um endereço de e-mail válido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

    }
}