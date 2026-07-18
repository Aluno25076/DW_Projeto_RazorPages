using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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



        // Data em que o jogo foi / será realizado
        [Required(ErrorMessage = "A data do jogo é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data do Jogo")]
        public DateOnly Day { get; set; }

        // Chave estrangeira para o campo onde o jogo se realiza
        [Required(ErrorMessage = "O campo é obrigatório.")]
        [Display(Name = "Campo")]
        public int FieldId { get; set; }

        // Propriedade de navegação para o campo de ténis
        [ForeignKey(nameof(FieldId))]
        public Field? Field { get; set; }

        /// <summary>
        /// Lista de participantes (Members) no jogo
        /// </summary>
        public ICollection<Member> Participants { get; set; } = [];

        // Relação de navegação: participantes neste jogo
        public ICollection<MatchParticipant> MatchParticipants { get; set; } = new List<MatchParticipant>();

    }
}
