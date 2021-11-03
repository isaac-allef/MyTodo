using System.Threading.Tasks;
using MyTodo.Models.InputModels;
using MyTodo.Models.EntityModels;

namespace MyTodo.Services.Interfaces
{
    public interface ICreateTodoService
    {
        Task<Todo> Execute(CreateTodoInputModel model);
    }
}