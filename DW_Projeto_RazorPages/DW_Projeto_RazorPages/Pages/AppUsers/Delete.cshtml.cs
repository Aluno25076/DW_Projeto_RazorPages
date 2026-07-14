using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DW_Projeto_RazorPages.Data.Model;
using DW_Projeto_RazorPages.Data;

namespace DW_Projeto_RazorPages.Pages.MyUserPages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public MyUser MyUser { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var myuser = await _context.AppUsers.FirstOrDefaultAsync(m => m.Id == id);
        if (myuser is null)
        {
            return NotFound();
        }
        else
        {
            MyUser = myuser;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var myuser = await _context.AppUsers.FindAsync(id);
        if (myuser != null)
        {
            MyUser = myuser;
            _context.AppUsers.Remove(MyUser);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
