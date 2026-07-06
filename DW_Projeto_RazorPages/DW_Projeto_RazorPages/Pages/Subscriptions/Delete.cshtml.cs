using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DW_Projeto_RazorPages.Data.Model;
using DW_Projeto_RazorPages.Data;

namespace DW_Projeto_RazorPages.Pages.SubscriptionPages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Subscription Subscription { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var subscription = await _context.Subscriptions.FirstOrDefaultAsync(m => m.Id == id);
        if (subscription is null)
        {
            return NotFound();
        }
        else
        {
            Subscription = subscription;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var subscription = await _context.Subscriptions.FindAsync(id);
        if (subscription != null)
        {
            Subscription = subscription;
            _context.Subscriptions.Remove(Subscription);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
