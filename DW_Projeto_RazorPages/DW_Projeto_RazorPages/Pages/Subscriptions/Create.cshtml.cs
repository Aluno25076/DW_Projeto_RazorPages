using System.Globalization;
using DW_Projeto_RazorPages.Data;
using DW_Projeto_RazorPages.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Pages.SubscriptionPages;

[Authorize(Roles = "Trainer")]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Subscription Subscription { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // atribuir o valor auxiliar da taxa ao atributo taxa de subscrição,
        // convertendo de string para decimal
        Subscription.Fee = Convert.ToDecimal(Subscription.FeeAux.Replace('.', ','), new CultureInfo("pt-PT"));

        

        try
        {
            _context.Subscriptions.Add(Subscription);
            await _context.SaveChangesAsync();
        }
        catch(Exception)
        {
            //TODO
            throw;
        }

        return RedirectToPage("./Index");
    }
}
