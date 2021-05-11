using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabWork_Aidin.DAL.Data;
using LabWork_Aidin.DAL.Entities;

namespace LabWork_Aidin.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly LabWork_Aidin.DAL.Data.ApplicationDbContext _context;

        public DetailsModel(LabWork_Aidin.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Dish Dish { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dish = await _context.Dishes
                .Include(d => d.DishGroup).FirstOrDefaultAsync(m => m.DishId == id);

            if (Dish == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
