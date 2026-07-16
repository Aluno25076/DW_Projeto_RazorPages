using DW_Projeto_RazorPages.Data;
using DW_Projeto_RazorPages.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Pages.SubscriptionPages;

[Authorize(Roles = "Trainer")]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
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
        Subscription = subscription;

        //isto guarda os dados que são enviados para o navegador,
        //de forma a garantir que o id do curso é mantido,
        //ou seja, que não foi alterado por um utilizador com más intenções
        HttpContext.Session.SetInt32("SubscriptionId", Subscription.Id);
        // para caso o projeto for do tipo MVC
        HttpContext.Session.SetString("action", "subscription/edit");

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        // ler dados do 'cookie' para garantir que não houve adulteração dos dados
        var idSubscirption = HttpContext.Session.GetInt32("SubscriptionId");
        var action = HttpContext.Session.GetString("action");

        if (idSubscirption == null || action == null) {
            // o utilizador demorou muito tempo a submeter o formulário ou adulterou os dados do 'cookie'
            ModelState.AddModelError(string.Empty, "Dados do formulário expiraram. Por favor, reinicie o processo novamente.");

            return Page();
        }

        if (idSubscirption != Subscription.Id || action != "subscription/edit")
        {
            // houve adulteração dos dados no browser
            return RedirectToPage("./Index");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Subscription).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SubscriptionExists(Subscription.Id))
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

    private bool SubscriptionExists(int id)
    {
        return _context.Subscriptions.Any(e => e.Id == id);
    }
}
