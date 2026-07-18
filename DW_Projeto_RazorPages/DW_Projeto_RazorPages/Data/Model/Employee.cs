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
       
            /// <summary>
            /// número de funcionário interno do clube
            /// </summary>
            [Display(Name = "Número de Funcionário")]
            public int? FuncNum { get; set; }

            /// <summary>
            /// salário do funcionário 
            /// </summary>
            [Required(ErrorMessage = "O funcionário precisa de ser pago.")]
            [Column(TypeName = "decimal(8,2)")]
            [Display(Name = "Salário")]
            [DataType(DataType.Currency)]
            public decimal Salary { get; set; }

           /// <summary>
           /// estado de emprego do funcionário 
           /// </summary>
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
           /// <summary>
           /// Funcionário ativo
           /// </summary>
            Active,
           /// <summary>
           /// Funcionário inativo / despedido
           /// </summary>
            Inactive
        }
    }

