using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CIT_195_RazorPagesMovie.Models;

namespace CIT_195_RazorPagesMovie.Data
{
    public class CIT_195_RazorPagesMovieContext : DbContext
    {
        public CIT_195_RazorPagesMovieContext (DbContextOptions<CIT_195_RazorPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<CIT_195_RazorPagesMovie.Models.Movie> Movie { get; set; } = default!;
    }
}
