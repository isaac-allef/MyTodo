using System.Threading.Tasks;
using MyTodo.Models.InputModels;
using MyTodo.Models.EntityModels;

namespace MyTodo.Facades.Interfaces
{
    public interface ITodoFacade
    {
        Task<Todo> Create(CreateTodoInputModel model);
        Task<Todo> Update(UpdateTodoInputModel model, int id);
        Task<Todo> Delete(int id);
    }
}