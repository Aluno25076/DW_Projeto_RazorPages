using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Data.Model
{
    /// <summary>
    /// Dados das subscrições/planos do clube de tenis
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// Chave primaria (PK)
        /// </summary>
        [Key]
        public int Id { get; set; }


        /// <summary>
        /// Pagamento da subcrição / taxa da subscrição
        /// </summary>
        [Precision(9,2)]
        public decimal Fee { get; set; }

        /// <summary>
        /// atributo auxiliar para a taxa, para garantir 
        /// que o pagamento possa ser guardado como uma moeda padrão
        /// </summary>
        [NotMapped] 
        [Required(ErrorMessage = "A {0} é obrigatória")] 
        [Display(Name = "Taxa")] 
        [StringLength(10)]
        [RegularExpression("[0-9]{1,7}([,.][0-9]{1,2})?",
           ErrorMessage = "A {0} deve ser um número com até 2 casas decimais")] 
        public string FeeAux { get; set; } = "";

        /// <summary>
        /// Descrição do Programa da subscrição
        /// </summary>
        [StringLength(300)]
        public string Program { get; set; } = "";

        /// <summary>
        /// Tipo de Duração da subscrição
        /// </summary>
        public enum Duration
        {
            Weekly,
            Monthly,
            Yearly
        }

        /// <summary>
        /// Lista de Membros inscritos no plano/subscrição
        /// </summary>
        public ICollection<Member> MembersList { get; set; } = [];
    }
}
