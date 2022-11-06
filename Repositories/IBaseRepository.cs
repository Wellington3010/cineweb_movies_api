using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.Repositories
{
    public interface IBaseRepository<T, Z>  where T : class
    {
        Task<T> FindById(Z id);

        IQueryable<T> ListItems();

        Task AddItem(T item);

        Task RemoveById(Z id);

        Task Update(T item);

        Task<List<T>> FindByGenre(string genre);

        Task<List<T>> FindAll();

        Task<T> FindByTitle(string title);
    }
}
