using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Data.Model
{
    /// <summary>
    /// Dados dos modelos de subscrições/planos do clube de tenis
    /// </summary>
    public class Subscription
    {
        // Identificador único da subscrição (chave primária)
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do modelo de subscrição
        /// </summary>
        [Required(ErrorMessage = "A {0} é obrigatória")]
        [StringLength(300)]
        public string Name { get; set; }


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
        [Display(Name = "Quota")] 
        [StringLength(10)]
        [RegularExpression("[0-9]{1,7}([,.][0-9]{1,2})?",
           ErrorMessage = "A {0} deve ser um número com até 2 casas decimais")] 
        public string FeeAux { get; set; } = "";

        /// <summary>
        /// Descrição do Programa do modelo de subscrição
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
            Quarterly,
            Semesterly,
            Yearly
        }

        // Relação de navegação: membros associados a esta subscrição (tabela intermédia)
        public ICollection<Subscribed> Subscribed { get; set; } = new List<Subscribed>();
    }
}