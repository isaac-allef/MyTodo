using System.Threading.Tasks;
using MyTodo.Models.EntityModels;
using MyTodo.Repositories.Interfaes.Db;
using MyTodo.Services.Interfaces;

namespace MyTodo.Services
{
    public class DeleteTodoService : IDeleteTodoService
    {
        private IGetTodoRepository _GetTodoRepository;
        private IDeleteTodoRepository _DeleteTodoRepository;
        public DeleteTodoService(IGetTodoRepository GetTodoRepository, 
                                    IDeleteTodoRepository DeleteTodoRepository)
        {
            this._GetTodoRepository = GetTodoRepository;
            this._DeleteTodoRepository = DeleteTodoRepository;
        }

        public async Task<Todo> Execute(int id)
        {
            var todo = await _GetTodoRepository.GetById(id);

            await _DeleteTodoRepository.Delete(todo);

            return todo;
        }
    }
}