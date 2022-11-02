using cineweb_movies_api.Context;
using cineweb_movies_api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.Repositories
{
    public class MovieRepository : IBaseRepository<Filme>
    {
        private MovieContext _movieContext { get; set; }
        public MovieRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public void AddItem(Filme item)
        {
            _movieContext.Movies.Add(item);
            _movieContext.SaveChanges();
        }

        public Filme FindById(Guid id)
        {
            return _movieContext.Movies.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<Filme> ListItems()
        {
            return _movieContext.Movies.AsQueryable();
        }

        public void RemoveById(Guid id)
        {
            _movieContext.Movies.Remove(FindById(id));
            _movieContext.SaveChanges();
        }

        public void Update(Filme item)
        {
            _movieContext.Entry<Filme>(item).State = EntityState.Modified;
            _movieContext.SaveChanges();
        }

        public List<Filme> FindByGenre(string genre)
        {
            return _movieContext.Movies.Where(x => x.Genero == genre).ToList();
        }

        public Filme FindByTitle(string title)
        {
            return _movieContext.Movies.Where(x => x.Titulo == title).FirstOrDefault();
        }

        public List<Filme> FindAll()
        {
            return _movieContext.Movies.ToList();
        }
    }
}
