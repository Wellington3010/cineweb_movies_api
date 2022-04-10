using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.Repositories
{
    public interface IBaseRepository<T>  where T : class
    {
        T FindById(Guid id);

        IQueryable<T> ListItems();

        void AddItem(T item);

        void RemoveById(Guid id);

        void Update(T item);

        List<T> FindByGenre(string genre);

        T FindByTitle(string title);

    }
}
