using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogClubWeb.Data;
using DogClubWeb.Model;

namespace DogClubWeb.Pages.Dogs
{
    public class IndexModel : PageModel
    {
        private readonly DogClubWeb.Data.AppDbContext _context;

        public IndexModel(DogClubWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Dog> Dog { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Dogs != null)
            {
                Dog = await _context.Dogs.ToListAsync();
            }
        }
    }
}
