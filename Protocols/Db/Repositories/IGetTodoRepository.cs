using System.Threading.Tasks;
using MyTodo.Models;

namespace MyTodo.Protocols.Db.Repositories
{
    public interface IGetTodoRepository
    {
        Task<Todo> GetById(int id);
    }
}