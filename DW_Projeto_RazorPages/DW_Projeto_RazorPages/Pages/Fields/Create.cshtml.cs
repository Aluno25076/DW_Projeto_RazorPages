using DW_Projeto_RazorPages.Data;
using DW_Projeto_RazorPages.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Pages.FieldPages;

[Authorize(Roles = "Trainer, Administrator")]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["FieldType"] = new SelectList(Enum.GetValues(typeof(Field.FieldType)).Cast<Field.FieldType>());
        return Page();
    }

    [BindProperty]
    public Field Field { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["FieldType"] = new SelectList(Enum.GetValues(typeof(Field.FieldType)).Cast<Field.FieldType>());
            return Page();
        }

        _context.Fields.Add(Field);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
