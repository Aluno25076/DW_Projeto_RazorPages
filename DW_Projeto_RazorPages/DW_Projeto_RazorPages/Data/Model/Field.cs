using System.ComponentModel.DataAnnotations;

namespace DW_Projeto_RazorPages.Data.Model
{
    /// <summary>
    /// Classe para representar os campos de ténis
    /// que existem no clube
    /// </summary>
            public class Field
            {/// <summary>
             /// Chave Primaria (PK)
             /// </summary>
                [Key]
                public int Id { get; set; }



        /// <summary>
        /// Dimensões do campo (máximo 9 caracteres, com máscara, ex: "64x32" em metros)
        /// </summary>
        [Required(ErrorMessage = "As dimensões do campo são obrigatórias.")]
        [StringLength(9, ErrorMessage = "As dimensões não podem exceder 9 caracteres.")]
        [Display(Name = "Dimensões")]
        public string Size { get; set; } = string.Empty;

        /// <summary>
        /// Número identificador do campo no clube (ex: Campo 1, Campo 2...)
        /// </summary>
        [Display(Name = "Número do Campo")]
        public int? Number { get; set; }

        /// <summary>
        /// Tipo de superfície do campo (obrigatório)
        /// </summary>
        [Required(ErrorMessage = "O tipo de campo é obrigatório.")]
        [Display(Name = "Tipo de Superfície")]
        public FieldType Type { get; set; }

        /// <summary>
        /// Relação de navegação: jogos realizados neste campo
        /// </summary>
        public ICollection<Match> Matches { get; set; } = new List<Match>();

        /// <summary>
        /// atributo para demonstrar o tipo de campo
        /// </summary>
        public enum FieldType
        {
            /// <summary>
            /// Piso de terra batida
            /// </summary>
            Clay,
            /// <summary>
            /// Piso de relva sintética
            /// </summary>
            SyntheticGrass,
            /// <summary>
            /// Piso de alcatrão 
            /// </summary>
            HardCourt,
            /// <summary>
            /// Piso de relva natural
            /// </summary>
            Grass,
            /// <summary>
            /// Campo coberto 
            /// </summary>
            Indoor
        }
    }
}
