using System.Threading.Tasks;
using MyTodo.Models;

namespace MyTodo.Protocols.Db.Repositories
{
    public interface IUpdateTodoRepository
    {
        Task<Todo> Update(Todo todo);
    }
}