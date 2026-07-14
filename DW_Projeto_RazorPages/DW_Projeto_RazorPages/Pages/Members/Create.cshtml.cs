using System.Globalization;
using DW_Projeto_RazorPages.Data;
using DW_Projeto_RazorPages.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Pages.MemberPages;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["SubscriptionFK"] = new SelectList(_context.Subscriptions.OrderBy(s => s.Name), "Id", "Name");
        return Page();
    }

    [BindProperty]
    public Member Member { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["SubscriptionsFK"] = new SelectList(_context.Subscriptions.OrderBy(s => s.Name), "Id", "Name", Member.SubscribedFK);
            return Page();
        }

        try
        {
            _context.Members.Add(Member);
            await _context.SaveChangesAsync();
        }
        catch (Exception) {
            //TODO
            throw;
        }

        return RedirectToPage("./Index");
    }
}
