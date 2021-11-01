using System.Collections.Generic;
using System.Threading.Tasks;
using MyTodo.Models;

namespace MyTodo.Protocols.Db.Repositories
{
    public interface IGetAllTodosRepository
    {
        Task<List<Todo>> GetAll(string search,
                                string orderBy,
                                string direction,
                                int per_page,
                                int page);
    }
}