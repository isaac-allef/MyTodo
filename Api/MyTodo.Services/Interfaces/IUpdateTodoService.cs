using System.Threading.Tasks;
using MyTodo.Models.InputModels;
using MyTodo.Models.EntityModels;

namespace MyTodo.Services.Interfaces
{
    public interface IUpdateTodoService
    {
        Task<Todo> Execute(UpdateTodoInputModel model, int id);
    }
}