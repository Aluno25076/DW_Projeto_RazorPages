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

    //Lista que guarda os IDs dos partecipantes
    [BindProperty]
    public List<int> SelectedParticipants { get; set; } = new();

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        // Isto remove a validação automática da navegação, caso contrario o ModelState ficará invalido
        ModelState.Remove("Match.Participants");

        if (!ModelState.IsValid)
        {
            //TODO fazer com que aceite exatamente 2 ou 4 jogadores

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

        // Carrega a Lista de Membros
        var members = await _context.Members.Where(m => SelectedParticipants.Contains(m.Id)).ToListAsync();

        // Associa os Membors da lista de participantes á Partida
        Match.Participants = members;

        _context.Matches.Add(Match);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}