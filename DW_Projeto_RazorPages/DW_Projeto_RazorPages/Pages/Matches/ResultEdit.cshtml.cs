using DW_Projeto_RazorPages.Data;
using DW_Projeto_RazorPages.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Pages.Matches;

public class ResultEditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public ResultEditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Match Match { get; set; } = default!;

    ///<summary>
    ///Lista que guarda os IDs dos vencedores
    ///<summary>
    [BindProperty]
    public List<int> SelectedWinners { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var match = await _context.Matches
                                    .Include(m => m.Participants)
                                    .Include(m => m.Result)
                                        .ThenInclude(r => r.Winners)
                                    .FirstOrDefaultAsync(m => m.Id == id);
        if (match is null)
        {
            return NotFound();
        }
        Match = match;

        ///<summary>
        ///carrega a lista dos partecipantes atuais (o que ja estava presente na db)
        ///<summary>
        SelectedWinners = match.Result?.Winners.Select(p => p.Id).ToList() ?? new();

        ViewData["WinnersFK"] = new MultiSelectList(match.Participants, "Id", "Name", SelectedWinners);
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        ///<summary>
        /// Isto remove a validação automática da navegação, caso contrario o ModelState ficará invalido
        ///<summary>
        ModelState.Remove("Match.Result.Winners");

        if (!ModelState.IsValid || (Match.Participants.Count == 2 && SelectedWinners.Count != 1) || (Match.Participants.Count == 4 && SelectedWinners.Count != 2) )
        {
            ///<summary>
            /// Só permite que dois ou quatro jogadores partecipem
            /// </summary>
            if (Match.Participants.Count == 2 && SelectedWinners.Count != 1)
            {
                ModelState.AddModelError(nameof(SelectedWinners), "Selecione apenas um vencedor.");
            }

            if (Match.Participants.Count == 4 && SelectedWinners.Count != 2)
            {
                ModelState.AddModelError(nameof(SelectedWinners), "Selecione exatamente dois vencedores.");
            }

            var matchForView = await _context.Matches
                                                .Include(m => m.Participants)
                                                .FirstOrDefaultAsync(m => m.Id == Match.Id);

            /// <summary>
            /// Usa uma lista ja existente ou cria uma nova lista
            /// </summary>
            ViewData["WinnersFK"] = new MultiSelectList(matchForView?.Participants ?? new List<Member>(), "Id", "Name", SelectedWinners);
            return Page();
        }

        var resultToUpdate = await _context.Matches.Include(m => m.Result.Winners).FirstOrDefaultAsync(m => m.Id == Match.Id);

        if (resultToUpdate is null)
        {
            return NotFound();
        }

        ///<summary>
        /// Atualiza a coleção de vencedores 
        /// começando por criar a nova lista de vencedores
        /// </summary>
        var newWinners = await _context.Members.Where(m => SelectedWinners.Contains(m.Id)).ToListAsync();

        ///<summary>
        /// Depois limpa a coleção
        /// </summary>
        resultToUpdate.Result.Winners.Clear();

        ///<summary>
        /// E volta a preencher
        /// </summary>
        foreach (var member in newWinners)
        {
            resultToUpdate.Result.Winners.Add(member);
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
