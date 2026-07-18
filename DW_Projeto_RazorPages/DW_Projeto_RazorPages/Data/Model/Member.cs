using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DW_Projeto_RazorPages.Data.Model
{
    /// <summary>
    /// Dados sobre os membros do clube de tenis
    /// o modelo herda da classe MyUser, ou seja
    /// ira possuir dados como o Nome, a Data de nacimento, o Numero de telephone e etc
    /// para alem disso, ira ter atributos especificos proprios
    /// como por exemplo a data de registo
    /// </summary>
    public class Member : MyUser
    {
        /// <summary>
        /// Número de sócio do membro no clube
        /// </summary>
        [Display(Name = "Número de Sócio")]
        public int? MemberId { get; set; }

        /// <summary>
        /// Data de registo do membro no clube (preenchida automaticamente com timestamp)
        /// </summary>
        [Display(Name = "Data de Registo")]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Relação de navegação: subscrições do membro (tabela intermédia Memb_Subsc)
        /// </summary>
        public ICollection<MemberSubscription> MemberSubscriptions { get; set; } = new List<MemberSubscription>();

        /// <summary>
        /// Lista de jogos em que o membro participa
        /// </summary>
        public ICollection<Match> Matches { get; set; } = [];
    }
}