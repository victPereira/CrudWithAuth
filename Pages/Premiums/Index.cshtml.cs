using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrudWithAuth.Data;
using CrudWithAuth.Models;

namespace CrudWithAuth.Pages_Premiums
{
    public class IndexModel : PageModel
    {
        private readonly CrudWithAuth.Data.ApplicationDbContext _context;

        public IndexModel(CrudWithAuth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Premium> Premium { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Premiuns != null)
            {
                Premium = await _context.Premiuns
                .Include(p => p.Student).ToListAsync();
            }
        }
    }
}
