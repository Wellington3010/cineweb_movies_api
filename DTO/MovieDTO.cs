using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.DTO
{
    public class MovieDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Genre { get; set; }

        public string MoviePoster { get; set; }

        public bool MovieHome { get; set; }

    }
}
