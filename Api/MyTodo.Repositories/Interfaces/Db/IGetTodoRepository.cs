using System.Threading.Tasks;
using MyTodo.Models.EntityModels;

namespace MyTodo.Repositories.Interfaes.Db
{
    public interface IGetTodoRepository
    {
        Task<Todo> GetById(int id);
    }
}