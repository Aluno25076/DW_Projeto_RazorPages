using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DW_Projeto_RazorPages.Data.Model;
using DW_Projeto_RazorPages.Data;

namespace DW_Projeto_RazorPages.Pages.MatchPages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Match> Match { get; set; } = default!;

    public IList<int> ParticipantIds { get; set; } = [];

    public async Task OnGetAsync()
    {
        Match = await _context.Matches.Include(m => m.Field).Include(m => m.Participants).Include(m => m.Result).ThenInclude(r => r.Winners).ToListAsync();
    }
}
