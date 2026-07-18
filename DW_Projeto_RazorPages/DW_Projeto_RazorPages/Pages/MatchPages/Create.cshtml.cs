using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DW_Projeto_RazorPages.Data.Model;
using DW_Projeto_RazorPages.Data;

namespace DW_Projeto_RazorPages.Pages.MatchPages;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Prepara a página de criação de um jogo,
    /// carregando a lista de campos para a dropdown
    /// </summary>
    public IActionResult OnGet()
    {
        // preencher a dropdown com os campos disponíveis
        // (mostra o atributo 'Size'; o value é o 'Id')
        ViewData["FieldId"] = new SelectList(_context.Fields, "Id", "Size");
        return Page();
    }

    [BindProperty]
    public Match Match { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    /// <summary>
    /// Processa a submissão do formulário de criação de um jogo
    /// </summary>
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            // repor a dropdown antes de voltar à página,
            // senão o select aparece vazio após um erro de validação
            ViewData["FieldId"] = new SelectList(_context.Fields, "Id", "Size");
            return Page();
        }

        _context.Matches.Add(Match);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}