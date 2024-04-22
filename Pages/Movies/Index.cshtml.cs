using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIT_195_RazorPagesMovie.Data;
using CIT_195_RazorPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CIT_195_RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly CIT_195_RazorPagesMovie.Data.CIT_195_RazorPagesMovieContext _context;

        public IndexModel(CIT_195_RazorPagesMovie.Data.CIT_195_RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from x in _context.Movie
                         select x;
            if (!string.IsNullOrEmpty(SearchString) )
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MovieGenre) )
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
