using System.Threading.Tasks;
using MyTodo.InputModels;
using MyTodo.Models;

namespace MyTodo.Protocols.Services
{
    public interface ICreateTodoService
    {
        Task<Todo> Execute(CreateTodoInputModel model);
    }
}