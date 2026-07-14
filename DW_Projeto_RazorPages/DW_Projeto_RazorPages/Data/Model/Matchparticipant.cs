
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Data.Model
{
    /// <summary>
    /// Tabela intermédia que representa a participação de um membro num jogo de ténis.
    /// Liga a tabela "Match" com a tabela "Members".
    /// Chave primária composta: (MatchFK, MemberFK).
    /// </summary>
    [PrimaryKey(nameof(MemberFK), nameof(MatchFK))] //chave primaria composta
    public class MatchParticipant
        {

            /// <summary>
            /// Chave estrangeira para o jogo (parte da chave primária composta)
            /// Propriedade de navegação para o jogo
            /// </summary>
            [ForeignKey(nameof(Match))]
            public int MatchFK { get; set; }
            public Match? Match { get; set; }

            /// <summary>
            /// Chave estrangeira para o membro / jogador (parte da chave primária composta)
            /// Propriedade de navegação para o membro
            /// </summary>
            [ForeignKey(nameof(Member))]
            public int MemberFK { get; set; }
            public Member? Member { get; set; }
        }
    }


