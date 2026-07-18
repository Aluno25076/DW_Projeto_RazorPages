using System.ComponentModel.DataAnnotations;

namespace DW_Projeto_RazorPages.Data.Model
{
    /// <summary>
    /// Classe para representar os utilizadores da aplicação
    /// estes dados identificam os utilizadores, independentemente 
    /// do tipo de utilizador (Membro, Funcionario)
    /// </summary>
    public class MyUser
    {
        /// <summary>
        /// Chave Primaria (PK)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome Completo do utilizador
        /// </summary>
        [StringLength(50)]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatorio!")]
        [Display(Name = "Nome Completo")]
        public string Name { get; set; } = "";

        /// <summary>
        /// Data de nascimento
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatorio!")]
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }

        /// <summary>
        /// Número de telephone
        /// </summary>
        [Display(Name = "Telemóvel")]
        [StringLength(19)]
        [RegularExpression(@"\+?[0-9]{9,18}", ErrorMessage = "O número de telemóvel deve conter apenas dígitos (entre 9 e 18) e pode começar com um sinal de mais.")]
        public string? CellPhone { get; set; }

        /// <summary>
        /// atributo para funcionar como FK entre a tabela dos MyUser (comentádo por indecisão )
        /// e a tabela da Autenticação
        /// </summary>
        [StringLength(40)]
        public string UserID { get; set; } = "";
    }
}
