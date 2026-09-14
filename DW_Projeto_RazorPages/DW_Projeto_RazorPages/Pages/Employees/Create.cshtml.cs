using System.Globalization;
using DW_Projeto_RazorPages.Data;
using DW_Projeto_RazorPages.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_RazorPages.Pages.EmployeePages;

[Authorize(Roles = "Administrator")]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["EmploymentStatus"] = new SelectList(Enum.GetValues(typeof(Employee.EmploymentStatus)).Cast<Employee.EmploymentStatus>());
        return Page();
    }

    [BindProperty]
    public Employee Employee { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["EmploymentStatus"] = new SelectList(Enum.GetValues(typeof(Employee.EmploymentStatus)).Cast<Employee.EmploymentStatus>());
            return Page();
        }

        // atribuir o valor auxiliar do salario do funcionario,
        // convertendo de string para decimal
        Employee.Salary = Convert.ToDecimal(Employee.SalaryAux.Replace('.', ','), new CultureInfo("pt-PT"));

        _context.Employees.Add(Employee);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
