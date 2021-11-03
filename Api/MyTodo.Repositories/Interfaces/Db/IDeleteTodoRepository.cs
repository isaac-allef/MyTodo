using System.Threading.Tasks;
using MyTodo.Models.EntityModels;

namespace MyTodo.Repositories.Interfaes.Db
{
    public interface IDeleteTodoRepository
    {
        Task<Todo> Delete(Todo todo);
    }
}