using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Interfaces.Repository
{
    public interface IBasicRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<string> Insert(T t);
        Task Update(T t);
        Task Delete(string id);
    }
}
