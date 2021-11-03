using System.Threading.Tasks;
using MyTodo.Models.EntityModels;

namespace MyTodo.Services.Interfaces
{
    public interface IGetTodoByIdService
    {
        Task<Todo> Execute(int id);
    }
}