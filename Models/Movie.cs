﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIT_195_RazorPagesMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(60,MinimumLength = 3)]
        [Required]
        public string Title { get; set; } = string.Empty; // initializing to string.Empty is optional

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z][a-zA-Z]*(\s+[A-Z][a-zA-Z]*)*$")]
        [Required]
        [StringLength(30)]
        public string? Genre { get; set; } = string.Empty; // optional as above

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]

        public decimal Price { get; set; } = 0;

        [RegularExpression(@"^(G|PG|R|X|NA)$")]
        [StringLength(5)]
        [Required]
        public string? Rating { get; set; } = string.Empty;
    }
}
