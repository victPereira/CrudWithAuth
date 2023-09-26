using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrudWithAuth.Data;
using CrudWithAuth.Models;

namespace CrudWithAuth.Pages_Premiums
{
    public class CreateModel : PageModel
    {
        private readonly CrudWithAuth.Data.ApplicationDbContext _context;

        public CreateModel(CrudWithAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Premium Premium { get; set; } = default!;
        

        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Premiuns == null || Premium == null)
            {
                return Page();
            }

            _context.Premiuns.Add(Premium);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
