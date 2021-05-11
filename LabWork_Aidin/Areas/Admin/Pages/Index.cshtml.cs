
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
    public class IndexModel : PageModel
    {
        private readonly LabWork_Aidin.DAL.Data.ApplicationDbContext _context;

        public IndexModel(LabWork_Aidin.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dish> Dish { get; set; }

        public async Task OnGetAsync()
        {
            Dish = await _context.Dishes
                .Include(d => d.DishGroup).ToListAsync();
        }
    }
}
