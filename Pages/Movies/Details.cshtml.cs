using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIT_195_RazorPagesMovie.Data;
using CIT_195_RazorPagesMovie.Models;

namespace CIT_195_RazorPagesMovie.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly CIT_195_RazorPagesMovie.Data.CIT_195_RazorPagesMovieContext _context;

        public DetailsModel(CIT_195_RazorPagesMovie.Data.CIT_195_RazorPagesMovieContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
