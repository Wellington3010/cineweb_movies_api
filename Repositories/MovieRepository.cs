using cineweb_movies_api.Context;
using cineweb_movies_api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.Repositories
{
    public class MovieRepository : IBaseRepository<Filme, Guid>
    {
        private ApplicationContext _movieContext { get; set; }
        public MovieRepository(ApplicationContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task AddItem(Filme item)
        {
            _movieContext.Filmes.Add(item);
            await _movieContext.SaveChangesAsync();
        }

        public async Task<Filme> FindById(Guid id)
        {
            return await _movieContext.Filmes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public IQueryable<Filme> ListItems()
        {
            return _movieContext.Filmes.AsQueryable();
        }

        public async Task RemoveById(Guid id)
        {
            var filme = _movieContext.Filmes.Where(x => x.Id == id).FirstOrDefault();
            _movieContext.Filmes.Remove(filme);
            await _movieContext.SaveChangesAsync();
        }

        public async Task Update(Filme item)
        {
            _movieContext.Filmes.Update(item);
            await _movieContext.SaveChangesAsync();
        }

        public async Task<List<Filme>> FindByGenre(string genre)
        {
            return  await _movieContext.Filmes.Where(x => x.Genero == genre).ToListAsync();
        }

        public async Task<Filme> FindByTitle(string title)
        {
            return await _movieContext.Filmes.Where(x => x.Titulo == title).FirstOrDefaultAsync();
        }

        public async Task<List<Filme>> FindAll()
        {
            return await _movieContext.Filmes.ToListAsync();
        }
    }
}
