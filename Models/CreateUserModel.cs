using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Valideixon.Models
{
    public class CreateUserModel
    {
        [Required(ErrorMessage = "Informe o usuário")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "O usuário deve conter entre 3 e 10 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Password { get; set; }

        [Range(0, 999.99, ErrorMessage = "Você ganha muito!")]
        public decimal Salary { get; set; }

        [EmailInUse]
        [BlockDomain("google.com")]
        public string Email { get; set; }
    }

    public class EmailInUseAttribute : ValidationAttribute
    {
        private static string GetErrorMessage() => $"Este e-mail já está em uso.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return (string) value == "hello@balta.io"
                ? new ValidationResult(GetErrorMessage())
                : ValidationResult.Success;
        }
    }
    
    public class BlockDomainAttribute : ValidationAttribute
    {
        public string Domain { get; set; }

        public BlockDomainAttribute(string domain) => Domain = domain;

        private static string GetErrorMessage() => $"Este domínio é inválido.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ((string) value).Contains(Domain)
                ? new ValidationResult(GetErrorMessage())
                : ValidationResult.Success;
        }
    }
}