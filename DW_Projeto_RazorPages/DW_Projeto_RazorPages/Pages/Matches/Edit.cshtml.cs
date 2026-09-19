using DW_Projeto_RazorPages.Data;
using DW_Projeto_RazorPages.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Pages.MatchPages;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Match Match { get; set; } = default!;

    /// <summary>
    /// Lista que guarda os IDs dos partecipantes
    /// </summary>
    [BindProperty]
    public List<int> SelectedParticipants { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var match = await _context.Matches.Include(m => m.Participants).FirstOrDefaultAsync(m => m.Id == id);
        if (match is null)
        {
            return NotFound();
        }
        Match = match;

        ///<summary>
        ///carrega a lista dos partecipantes atuais (o que ja estava presente na db)
        ///<summary>
        SelectedParticipants = match.Participants.Select(p => p.Id).ToList();

        ViewData["FieldFK"] = new SelectList(_context.Fields, "Id", "Number");
        ViewData["ParticipantsFK"] = new MultiSelectList(_context.Members, "Id", "Name", SelectedParticipants);
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        ///<summary>
        /// Isto remove a validação automática da navegação, caso contrario o ModelState ficará invalido
        ///<summary>
        ModelState.Remove("Match.Participants");
        ModelState.Remove("Match.Result");

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

        var matchToUpdate = await _context.Matches.Include(m => m.Participants).Include(m => m.Result).ThenInclude(r =>  r.Wienners).FirstOrDefaultAsync(m => m.Id == Match.Id);

        if (matchToUpdate is null)
        {
            return NotFound();
        }

        ///<summary>
        /// Atualiza os campos 
        /// </summary>
        matchToUpdate.Day = Match.Day;
        matchToUpdate.FieldFK = Match.FieldFK;

        ///<summary>
        /// Atualiza a coleção de participantes 
        /// começando por criar a nova lista de participantes
        /// </summary>
        var newParticipants = await _context.Members.Where(m => SelectedParticipants.Contains(m.Id)).ToListAsync();

        ///<summary>
        /// Depois limpa a coleção
        /// </summary>
        matchToUpdate.Participants.Clear();

        ///<summary>
        /// Inclusive o vencedores anteriores, uma vez que podera ter havido alteração nos partecipantes
        /// </summary>
        matchToUpdate.Result.Wienners.Clear();

        ///<summary>
        /// E volta a preencher
        /// </summary>
        foreach (var member in newParticipants)
        {
            matchToUpdate.Participants.Add(member);
        }

        //_context.Attach(Match).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MatchExists(Match.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool MatchExists(int id)
    {
        return _context.Matches.Any(e => e.Id == id);
    }
}
