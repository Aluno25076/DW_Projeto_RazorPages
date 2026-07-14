
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

namespace DW_Projeto_RazorPages.Data.Model
{
    /// <summary>
    /// Tabela intermédia que representa a participação de um membro num jogo de ténis.
    /// Liga a tabela "Match" com a tabela "Members".
    /// Chave primária composta: (MatchId, MemberId).
    /// </summary>
    public class MatchParticipant
        {
            // Chave estrangeira para o jogo (parte da chave primária composta)
            [Required]
            public int MatchId { get; set; }

            // Chave estrangeira para o membro / jogador (parte da chave primária composta)
            [Required]
            public int MemberId { get; set; }

            // Propriedade de navegação para o jogo
            [ForeignKey(nameof(MatchId))]
            public Match? Match { get; set; }

            // Propriedade de navegação para o membro
            [ForeignKey(nameof(MemberId))]
            public Member? Member { get; set; }
        }
    }


