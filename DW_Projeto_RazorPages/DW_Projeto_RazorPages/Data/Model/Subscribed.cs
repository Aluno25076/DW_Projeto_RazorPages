using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Data.Model
{
    /// <summary>
    /// Classe que do relacionamento entre membros e subscrições
    /// Dados das subscrições que os Membros increveram-se
    /// </summary>
    [PrimaryKey(nameof(MemberFK), nameof(SubscriptionFK))] //chave primaria composta
    public class Subscribed
    {
        /// <summary>
        /// Membro(subscritor)
        /// </summary>
        [ForeignKey(nameof(Member))]
        [Display(Name = "Membro")]
        public int MemberFK { get; set; }
        public Member Member { get; set; } = null!;

        /// <summary>
        /// Subscrição
        /// </summary>
        [ForeignKey(nameof(Subscription))]
        [Display(Name = "Subscription")]
        public int SubscriptionFK { get; set; }
        public Subscription Subscription { get; set; } = null!;

        public DateTime ExpirationDate { get; set; }


    }
}
