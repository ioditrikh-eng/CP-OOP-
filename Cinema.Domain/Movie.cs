using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int DurationMinutes { get; set; }
        public string Director { get; set; }
        public string PosterUrl { get; set; }
        public int AgeRestriction { get; set; } // 0,12,16,18

        public string GetInfo() => $"{Title} ({DurationMinutes} хв, {Genre})";
        public bool Validate() => !string.IsNullOrEmpty(Title) && DurationMinutes > 0;
    }
}