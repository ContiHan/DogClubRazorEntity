using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogClubWeb.Data;
using DogClubWeb.Model;

namespace DogClubWeb.Pages.Dogs
{
    public class EditModel : PageModel
    {
        private readonly DogClubWeb.Data.AppDbContext _context;

        public EditModel(DogClubWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dog Dog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dogs == null)
            {
                return NotFound();
            }

            var dog =  await _context.Dogs.FirstOrDefaultAsync(m => m.Id == id);
            if (dog == null)
            {
                return NotFound();
            }
            Dog = dog;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(Dog.Id))
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

        private bool DogExists(int id)
        {
          return (_context.Dogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
