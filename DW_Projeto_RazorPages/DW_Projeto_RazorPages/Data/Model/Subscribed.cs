using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DW_Projeto_RazorPages.Data.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Subscribed
    {
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey(nameof(Member))]
        [Display(Name = "Membro")]
        public int MemberFK { get; set; }
        public Member Member { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey(nameof(Subscription))]
        [Display(Name = "Subscription")]
        public int SubscriptionFK { get; set; }
        public Subscription Subscription { get; set; } = null!;

        public DateTime ExpirationDate { get; set; }


    }
}
