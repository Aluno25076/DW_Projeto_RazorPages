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
        /// Identificador atribuido para cada membro, para o identificar de forma unica 
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Data e hora da matricula do Membro
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatorio!")]
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;


        /// <summary>
        /// Subscrição do qual o membro está incrito
        /// </summary>
        //[ForeignKey(nameof(Subscribed))]
        //[Display(Name = "Subcrito")]
        //public string SubscribedFK { get; set; }

        // Relação de navegação: subscrições do membro (tabela intermédia Memb_Subsc)
        public ICollection<Subscribed> Subscribed { get; set; } = new List<Subscribed>();
    }
}
