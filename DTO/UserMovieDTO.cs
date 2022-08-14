using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.DTO
{
    public class UserMovieDTO
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Genre { get; set; }

        public bool HomeMovie { get; set; }

        public string MoviePoster { get; set; }

        public string Sinopse { get; set; }

        public bool Active { get; set; }
    }
}
