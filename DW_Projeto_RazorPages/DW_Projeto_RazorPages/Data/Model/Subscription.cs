using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Data.Model
{
    /// <summary>
    /// Enumerado que representa a duração de uma subscrição do clube.
    /// </summary>
    public enum SubscriptionDuration
    {
       
        Monthly,
        Quarterly,
        SemiAnnual,
        Annual
    }

    /// <summary>
    /// Representa um tipo de subscrição / plano disponível no clube de ténis.
    /// Equivalente à tabela "Subscription" na base de dados.
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// Identificador único da subscrição (chave primária)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Valor da quota da subscrição (obrigatório, precisão 8 dígitos com 2 decimais)
        /// </summary>
        [Required(ErrorMessage = "O valor da quota é obrigatório.")]
        [Column(TypeName = "decimal(8,2)")]
        [Display(Name = "Quota (€)")]
        [DataType(DataType.Currency)]
        public decimal Fee { get; set; }

        /// <summary>
        /// Programa / descrição da subscrição (ex: "Ténis Sénior", "Ténis Jovem")
        /// </summary>
        [Display(Name = "Programa")]
        public string? Program { get; set; }

        /// <summary>
        /// Duração da subscrição (obrigatório)
        /// </summary>
        [Required(ErrorMessage = "A duração é obrigatória.")]
        [Display(Name = "Duração")]
        public SubscriptionDuration Duration { get; set; }

        /// <summary>
        /// Relação de navegação: membros associados a esta subscrição (tabela intermédia)
        /// </summary>
        public ICollection<MemberSubscription> MemberSubscriptions { get; set; } = new List<MemberSubscription>();
    }
}