using System.Threading.Tasks;
using MyTodo.Models.EntityModels;

namespace MyTodo.Repositories.Interfaes.Db
{
    public interface IUpdateTodoRepository
    {
        Task<Todo> Update(Todo todo);
    }
}