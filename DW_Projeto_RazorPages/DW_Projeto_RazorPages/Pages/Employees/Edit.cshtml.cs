using DW_Projeto_RazorPages.Data;
using DW_Projeto_RazorPages.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Pages.EmployeePages;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
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
        Employee = employee;

        //isto guarda os dados que são enviados para o navegador,
        //de forma a garantir que o id do funcionario é mantido,
        //ou seja, que não foi alterado por um utilizador com más intenções
        HttpContext.Session.SetInt32("EmployeeId", Employee.Id);
        // para caso o projeto for do tipo MVC
        HttpContext.Session.SetString("action", "employee/edit");

        ViewData["EmploymentStatus"] = new SelectList(Enum.GetValues(typeof(Employee.EmploymentStatus)).Cast<Employee.EmploymentStatus>());
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["EmploymentStatus"] = new SelectList(Enum.GetValues(typeof(Employee.EmploymentStatus)).Cast<Employee.EmploymentStatus>());
            return Page();
        }

        _context.Attach(Employee).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmployeeExists(Employee.Id))
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

    private bool EmployeeExists(int id)
    {
        return _context.Employees.Any(e => e.Id == id);
    }
}
