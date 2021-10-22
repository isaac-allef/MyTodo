using System.Threading.Tasks;
using MyTodo.Models;

namespace MyTodo.Protocols.Db.Repositories
{
    public interface IDeleteTodoRepository
    {
        Task<Todo> Delete(Todo todo);
    }
}