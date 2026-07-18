using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DW_Projeto_RazorPages.Data.Model;
using DW_Projeto_RazorPages.Data;

namespace DW_Projeto_RazorPages.Pages.SubscriptionPages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Subscription> Subscription { get; set; } = default!;

    public async Task OnGetAsync()
    {
        /*
       * SELECT * 
       * FROM Courses c INNER JOIN Subscription s ON memb.SubscriptionFK = s.Id
       *                INNER JOIN Members m ON memb.SubscriptionFK = m.Id
       */
        Subscription = await _context.Subscriptions.Include(s => s.Subscribers).ToListAsync();
    }
}
