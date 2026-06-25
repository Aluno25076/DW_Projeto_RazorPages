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

   
   

            // Dimensões do campo (máximo de 9 caracteres, com máscara, exemplo: "64x32" em metros)
            [Required(ErrorMessage = "As dimensões do campo são obrigatórias.")]
            [StringLength(9, ErrorMessage = "As dimensões não podem exceder 9 caracteres.")]
            [Display(Name = "Dimensões")]
            public string Size { get; set; } = string.Empty;

            // Número  do campo no clube 
            [Display(Name = "Número do Campo")]
            public int? Number { get; set; }

            // Tipo de superfície do campo 
            [Required(ErrorMessage = "O tipo de campo é obrigatório.")]
            [Display(Name = "Tipo de superfície e cobertura")]
            public FieldType Type { get; set; }


            /// <summary>
            /// atributo para demonstrar o tipo de campo
            /// </summary>
            public enum FieldType
        {
            // Piso de terra batida
            Clay,
            // Piso de relva sintética
            SyntheticGrass,
            // Piso de alcatrão 
            HardCourt,
            // Piso de relva natural
            Grass,
            // Campo coberto 
            Indoor
        }
    }
}
