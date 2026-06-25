using System.ComponentModel.DataAnnotations;

namespace DW_Projeto_RazorPages.Data.Model
{


    /// <summary>
    /// Classe para representar as partidas organizadas e completadas da aplicação
    /// estes dados demonstram os resultados das partidas, participantes , o campo em que foi jogada e vencedores
    /// </summary>
    public class Match
    {
        /// <summary>
        /// Chave Primaria (PK)
        /// </summary>
        [Key]
        public int Id { get; set; }

       

        /// <summary>
        /// dia da partida
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatorio!")]
        [Display(Name = "Data em que a partida decorreu ou vai ocorrer")]
        public DateOnly Day { get; set; }


        /// <summary>
        /// campo da partida
        /// </summary>

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatorio!")]
        [Display(Name = "ID do campo da partida")]
        public string Field { get; set; } = "";


    }
}
