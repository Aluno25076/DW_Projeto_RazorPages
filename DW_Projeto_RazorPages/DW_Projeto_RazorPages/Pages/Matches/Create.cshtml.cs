using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DW_Projeto_RazorPages.Data.Model;
using DW_Projeto_RazorPages.Data;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Pages.MatchPages;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {

        /// <summary>
        /// preencher a dropdown com os campos disponíveis
        /// (mostra o atributo 'Size'; o value é o 'Id')
        /// </summary>
        /// <returns></returns>

        ViewData["FieldFK"] = new SelectList(_context.Fields, "Id", "Number");
        ViewData["ParticipantsFK"] = new MultiSelectList(_context.Members, "Id", "Name");
        return Page();
    }

    [BindProperty]
    public Match Match { get; set; } = default!;

    ///<summary>
    ///Lista que guarda os IDs dos partecipantes
    ///<summary>
    [BindProperty]
    public List<int> SelectedParticipants { get; set; } = new();

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        ///<summary>
        /// Isto remove a validação automática da navegação, caso contrario o ModelState ficará invalido
        ///<summary>
        ModelState.Remove("Match.Participants");

        if (!ModelState.IsValid || (SelectedParticipants.Count != 2 && SelectedParticipants.Count != 4))
        {
            ///<summary>
            /// Só permite que dois ou quatro jogadores partecipem
            /// </summary>
            if (SelectedParticipants.Count != 2 && SelectedParticipants.Count != 4)
            {
                ModelState.AddModelError(nameof(SelectedParticipants), "Escolha dois ou quatro participantes.");
            }
                

            /// <summary>
            /// repor a dropdown antes de voltar à página,
            /// senão o select aparece vazio após um erro de validação (mostra o atributo 'Size'; o value é o 'Id')
            /// </summary>
            /// <returns></returns>
            ViewData["FieldFK"] = new SelectList(_context.Fields, "Id", "Number", Match.FieldFK);

            /// <summary>
            /// Usa a Lista SelectedParticipants
            /// </summary>
            ViewData["ParticipantsFK"] = new MultiSelectList(_context.Members, "Id", "Name", SelectedParticipants);
            return Page();
        }


        ///<summary>
        /// Carrega a Lista de Membros
        /// </summary> 
        var members = await _context.Members.Where(m => SelectedParticipants.Contains(m.Id)).ToListAsync();

        ///<summary>
        /// Associa os Membors da lista de participantes á Partida
        /// </summary>
        Match.Participants = members;

        _context.Matches.Add(Match);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}