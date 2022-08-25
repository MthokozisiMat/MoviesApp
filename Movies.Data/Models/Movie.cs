using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public int ReleaseYear { get; set; }
        public int Genre { get; set; }
    }
}
