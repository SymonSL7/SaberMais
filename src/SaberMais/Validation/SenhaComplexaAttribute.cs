using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaberMais.Validation
{
    public class SenhaComplexaAttribute : ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
                var senha = value.ToString();
                var mensagemPadrao = "A senha deve conter no mínimo 8 caracteres, uma letra maiúscula, uma minúscula, um número e um caractere especial";

            if (senha.Length < 8)
            {
                return new ValidationResult(mensagemPadrao);
            }
            if (!senha.Any(char.IsUpper))
            {
                return new ValidationResult(mensagemPadrao);
            }
            if (!senha.Any(char.IsLower))
            {
                return new ValidationResult(mensagemPadrao);
            }
            if (!senha.Any(char.IsDigit))
            {
                return new ValidationResult(mensagemPadrao);
            }
            if (senha.All(char.IsLetterOrDigit)) // Verifica se não há caracteres especiais
            {
                return new ValidationResult(mensagemPadrao);
            }
        }

        return ValidationResult.Success;
    }

    }
}