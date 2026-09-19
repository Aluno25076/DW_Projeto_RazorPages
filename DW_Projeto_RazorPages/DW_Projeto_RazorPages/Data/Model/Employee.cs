using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
            public int FuncNum { get; set; }

            /// <summary>
            /// salário do funcionário 
            /// </summary>
            [Precision(9,2)]
            [Display(Name = "Salário")]
            public decimal Salary { get; set; }

        /// <summary>
        /// atributo auxiliar para a taxa, para garantir 
        /// que o salario possa ser guardado como uma moeda padrão
        /// </summary>
        [NotMapped]
        [Required(ErrorMessage = "O funcionário precisa de ser pago.")]
        [Display(Name = "Salário")]
        [StringLength(10)]
        [RegularExpression("[0-9]{1,7}([,.][0-9]{1,2})?",
        ErrorMessage = "A {0} deve ser um número com até 2 casas decimais")]
        public string SalaryAux { get; set; } = "";


        /// <summary>
        /// estado de emprego do funcionário 
        /// </summary>
        [Required(ErrorMessage = "O estado de emprego é obrigatório.")]
            [Display(Name = "Estado de Emprego")]
            public EmploymentStatus Status { get; set; }

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
    }

