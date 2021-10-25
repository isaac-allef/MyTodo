using System.Threading.Tasks;
using MyTodo.Models;

namespace MyTodo.Protocols.Services
{
    public interface IDeleteTodoService
    {
        Task<Todo> Execute(int id);
    }
}