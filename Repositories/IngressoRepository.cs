using cineweb_movies_api.Context;
using cineweb_movies_api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.Repositories
{
    public class IngressoRepository : IBaseRepository<Ingresso, int>
    {
        private ApplicationContext _applicationContext { get; set; }

        public IngressoRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Ingresso> FindById(int id)
        {
            return await _applicationContext.Ingressos.Where(x => x.IdIngresso == id).FirstOrDefaultAsync();
        }

        public IQueryable<Ingresso> ListItems()
        {
            return _applicationContext.Ingressos.AsQueryable();
        }

        public async Task AddItem(Ingresso item)
        {
            _applicationContext.Ingressos.Add(item);
            await _applicationContext.SaveChangesAsync();   
        }

        public async Task RemoveById(int id)
        {
            var ingresso = _applicationContext.Ingressos.Where(x => x.IdIngresso == id).FirstOrDefault();
            _applicationContext.Ingressos.Remove(ingresso);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task Update(Ingresso item)
        {
            _applicationContext.Ingressos.Update(item);
            await _applicationContext.SaveChangesAsync();
        }

        public Task<List<Ingresso>> FindByGenre(string genre)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ingresso>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Ingresso> FindByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
