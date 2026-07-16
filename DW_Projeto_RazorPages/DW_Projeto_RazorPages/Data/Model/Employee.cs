using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DW_Projeto_RazorPages.Data.Model
{
    /// <summary>
    /// Classe para representar os funcionários do clube
    ///  que em torno vão herdar de utilizadores
    /// </summary>
    public class Employee : MyUser
    {
       
            // número de funcionário interno do clube
            [Display(Name = "Número de Funcionário")]
            public int? FuncNum { get; set; }

            // salário do funcionário 
            [Required(ErrorMessage = "O funcionário precisa de ser pago.")]
            [Column(TypeName = "decimal(8,2)")]
            [Display(Name = "Salário")]
            [DataType(DataType.Currency)]
            public decimal Salary { get; set; }

            // estado de emprego do funcionário 
            [Required(ErrorMessage = "O estado de emprego é obrigatório.")]
            [Display(Name = "Estado de Emprego")]
            public EmploymentStatus EmploymentStatus { get; set; }
        }

        /// <summary>
        /// Estado do funcionário
        /// para saber se ainda  está a trabalhar no clube ou não
        /// </summary>
        public enum EmploymentStatus
        {
            // Funcionário ativo
            Active,
            // Funcionário inativo / despedido
            Inactive
        }
    }

