using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DW_Projeto_RazorPages.Data.Model
{

        /// <summary>
        /// Tabela intermédia que representa a associação entre um membro e uma subscrição.
        /// Equivalente à tabela "Memb_Subsc" na base de dados.
        /// Chave primária composta: (MemberId, SubscriptionId).
        /// </summary>
        public class MemberSubscription
        {
            /// <summary>
            /// Chave estrangeira para o membro (parte da chave primária composta)
            /// </summary>
            [Required]
            public int MemberId { get; set; }

            /// <summary>
            /// Chave estrangeira para a subscrição (parte da chave primária composta)
            /// </summary>
            [Required]
            public int SubscriptionId { get; set; }

            /// <summary>
            /// Data de expiração da subscrição do membro (obrigatória)
            /// </summary>
            [Required(ErrorMessage = "A data de expiração é obrigatória.")]
            [Display(Name = "Data de Expiração")]
            [DataType(DataType.Date)]
            public DateOnly ExpirationDate { get; set; }

            /// <summary>
            /// Propriedade de navegação para o membro
            /// </summary>
            [ForeignKey(nameof(MemberId))]
            public Member? Member { get; set; }

            /// <summary>
            /// Propriedade de navegação para a subscrição
            /// </summary>
            [ForeignKey(nameof(SubscriptionId))]
            public Subscription? Subscription { get; set; }
        }
    }
 