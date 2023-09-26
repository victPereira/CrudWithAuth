using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudWithAuth.Data;
using CrudWithAuth.Models;

namespace CrudWithAuth.Pages_Premiums
{
    public class EditModel : PageModel
    {
        private readonly CrudWithAuth.Data.ApplicationDbContext _context;

        public EditModel(CrudWithAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Premium Premium { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Premiuns == null)
            {
                return NotFound();
            }

            var premium =  await _context.Premiuns.FirstOrDefaultAsync(m => m.Id == id);
            if (premium == null)
            {
                return NotFound();
            }
            Premium = premium;
           ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email");
            return Page();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Premium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PremiumExists(Premium.Id))
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

        private bool PremiumExists(int id)
        {
          return (_context.Premiuns?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
