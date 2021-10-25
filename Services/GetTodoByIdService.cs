using System.Threading.Tasks;
using MyTodo.Models;
using MyTodo.Protocols.Db.Repositories;
using MyTodo.Protocols.Services;

namespace MyTodo.Services
{
    public class GetTodoByIdService : IGetTodoByIdService
    {
        private IGetTodoRepository _GetTodoRepository;
        public GetTodoByIdService(IGetTodoRepository GetTodoRepository)
        {
            this._GetTodoRepository = GetTodoRepository;
        }

        public async Task<Todo> Execute(int id)
        {
            var todo = await _GetTodoRepository.GetById(id);

            return todo;
        }
    }
}