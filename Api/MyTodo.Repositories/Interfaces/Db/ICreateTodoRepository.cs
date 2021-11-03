using System.Threading.Tasks;
using MyTodo.Models.EntityModels;

namespace MyTodo.Repositories.Interfaes.Db
{
    public interface ICreateTodoRepository
    {
        Task<Todo> Create(Todo todo);
    }
}