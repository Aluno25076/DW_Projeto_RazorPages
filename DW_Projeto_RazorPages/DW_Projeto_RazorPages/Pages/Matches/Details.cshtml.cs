using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DW_Projeto_RazorPages.Data.Model;
using DW_Projeto_RazorPages.Data;

namespace DW_Projeto_RazorPages.Pages.MatchPages;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Match Match { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var match = await _context.Matches.FirstOrDefaultAsync(m => m.Id == id);
        if (match is null)
        {
            return NotFound();
        }
        else
        {
            Match = match;
        }

        return Page();
    }
}
