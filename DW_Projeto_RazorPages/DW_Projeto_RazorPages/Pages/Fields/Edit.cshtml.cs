using DW_Projeto_RazorPages.Data;
using DW_Projeto_RazorPages.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Pages.FieldPages;

[Authorize(Roles = "Trainer, Administrator")]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
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
        Field = field;
        ViewData["FieldType"] = new SelectList(Enum.GetValues(typeof(Field.FieldType)).Cast<Field.FieldType>());
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["FieldType"] = new SelectList(Enum.GetValues(typeof(Field.FieldType)).Cast<Field.FieldType>());
            return Page();
        }

        _context.Attach(Field).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FieldExists(Field.Id))
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

    private bool FieldExists(int id)
    {
        return _context.Fields.Any(e => e.Id == id);
    }
}
