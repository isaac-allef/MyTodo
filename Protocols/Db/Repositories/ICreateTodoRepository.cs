using System.Threading.Tasks;
using MyTodo.Models;

namespace MyTodo.Protocols.Db.Repositories
{
    public interface ICreateTodoRepository
    {
        Task<Todo> Create(Todo todo);
    }
}