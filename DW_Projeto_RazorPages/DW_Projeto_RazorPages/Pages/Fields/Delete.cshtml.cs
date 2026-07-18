using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DW_Projeto_RazorPages.Data.Model;
using DW_Projeto_RazorPages.Data;

namespace DW_Projeto_RazorPages.Pages.FieldPages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Field Field { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var field = await _context.Fields.FirstOrDefaultAsync(m => m.Id == id);
        if (field is null)
        {
            return NotFound();
        }
        else
        {
            Field = field;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var field = await _context.Fields.FindAsync(id);
        if (field != null)
        {
            Field = field;
            _context.Fields.Remove(Field);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
