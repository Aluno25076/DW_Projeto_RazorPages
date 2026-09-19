using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DW_Projeto_RazorPages.Data.Model;
using DW_Projeto_RazorPages.Data;

namespace DW_Projeto_RazorPages.Pages.Members;

public class RankingIndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public RankingIndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Member> Member { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Member = await _context.Members
                                .Include(m => m.Subscription)
                                .Include(m => m.Matches)
                                .ThenInclude(p => p.Result)
                                .ThenInclude(r => r.Wienners)
                                .OrderByDescending(m => m.Wins.Count)
                                .ToListAsync();
    }
}
