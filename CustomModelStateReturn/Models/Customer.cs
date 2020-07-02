using System.ComponentModel.DataAnnotations;

namespace CustomModelStateReturn.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "O Nome Completo deve ser informado.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Nome Completo deve ter entre 5 e 100 caracteres.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "O Nome de Preferência deve ser informado.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O Nome de Preferência deve ter entre 3 e 20 caracteres.")]
        public string PreferredName { get; set; }
    }
}
