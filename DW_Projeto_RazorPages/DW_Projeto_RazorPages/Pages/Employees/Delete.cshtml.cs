using DW_Projeto_RazorPages.Data;
using DW_Projeto_RazorPages.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Pages.EmployeePages;

[Authorize(Roles = "Administrator")]
public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Employee Employee { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);
        if (employee is null)
        {
            return NotFound();
        }
        else
        {
            Employee = employee;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var employee = await _context.Employees.FindAsync(id);
        if (employee != null)
        {
            Employee = employee;
            _context.Employees.Remove(Employee);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
