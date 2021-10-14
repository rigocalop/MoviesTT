using MoviesTT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesTT.Models
{
    public class Movie
    {
        public long id { get; set; }
        public string title { get; set; } = "";
        public string overview { get; set; } = "";
        public string backdrop_path { get; set; } = "";
        public string poster_path { get; set; } = "";
        public double vote_average { get; set; } = 0.0;
        public string release { get; set; } = "";
        public string studio { get; set; } = "";
        public string genres { get; set; } = "";
    }
}