using System.Threading.Tasks;
using MyTodo.Models;

namespace MyTodo.Protocols.Services
{
    public interface IGetTodoByIdService
    {
        Task<Todo> Execute(int id);
    }
}