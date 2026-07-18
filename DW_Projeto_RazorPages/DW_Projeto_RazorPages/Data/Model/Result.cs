using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DW_Projeto_RazorPages.Data.Model
{
    /// <summary>
    /// Resultado de um jogo de ténis.
    /// a um jogo, e cada jogo tem no máximo um resultado.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Chave Primária (PK)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Resultado em sets (ex: "6-4, 3-6, 7-5")
        /// </summary>
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [StringLength(50)]
        [Display(Name = "Resultado (sets)")]
        public string SetScores { get; set; } = "";

        /// <summary>
        /// Nome/descrição do vencedor do jogo
        /// </summary>
        [StringLength(50)]
        [Display(Name = "Vencedor")]
        public string? Winner { get; set; }

       
        /// <summary>
        /// FK para o jogo a que este resultado pertence
        /// </summary>
        [ForeignKey(nameof(Match))]
        [Display(Name = "Jogo")]
        public int MatchFK { get; set; }

        /// <summary>
        /// Jogo a que este resultado pertence
        /// </summary>
        [ValidateNever]
        public Match Match { get; set; } = null!;

    }
}