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
    public class DetailsModel : PageModel
    {
        private readonly DogClubWeb.Data.AppDbContext _context;

        public DetailsModel(DogClubWeb.Data.AppDbContext context)
        {
            _context = context;
        }

      public Dog Dog { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dogs == null)
            {
                return NotFound();
            }

            var dog = await _context.Dogs.FirstOrDefaultAsync(m => m.Id == id);
            if (dog == null)
            {
                return NotFound();
            }
            else 
            {
                Dog = dog;
            }
            return Page();
        }
    }
}
