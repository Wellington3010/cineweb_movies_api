using cineweb_movies_api.Context;
using cineweb_movies_api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.Repositories
{
    public class MovieRepository : IBaseRepository<Movie>
    {
        private MovieContext _movieContext { get; set; }
        public MovieRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public void AddItem(Movie item)
        {
            _movieContext.Movies.Add(item);
            _movieContext.SaveChanges();
        }

        public Movie FindById(Guid id)
        {
            return _movieContext.Movies.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<Movie> ListItems()
        {
            return _movieContext.Movies.AsQueryable();
        }

        public void RemoveById(Guid id)
        {
            _movieContext.Movies.Remove(FindById(id));
            _movieContext.SaveChanges();
        }

        public void Update(Movie item)
        {
            _movieContext.Entry<Movie>(item).State = EntityState.Modified;
            _movieContext.SaveChanges();
        }

        public List<Movie> FindByGenre(string genre)
        {
            return _movieContext.Movies.Where(x => x.Genre == genre).ToList();
        }

        public Movie FindByTitle(string title)
        {
            return _movieContext.Movies.Where(x => x.Title == title).FirstOrDefault();
        }
    }
}
