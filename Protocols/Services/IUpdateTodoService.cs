using System.Threading.Tasks;
using MyTodo.InputModels;
using MyTodo.Models;

namespace MyTodo.Protocols.Services
{
    public interface IUpdateTodoService
    {
        Task<Todo> Execute(UpdateTodoInputModel model, int id);
    }
}