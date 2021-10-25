using System.Threading.Tasks;
using MyTodo.InputModels;
using MyTodo.Models;
using MyTodo.Protocols.Db.Repositories;
using MyTodo.Protocols.Services;

namespace MyTodo.Services
{
    public class UpdateTodoService : IUpdateTodoService
    {
        private IGetTodoRepository _GetTodoRepository;
        private IUpdateTodoRepository _UpdateTodoRepository;
        public UpdateTodoService(IGetTodoRepository GetTodoRepository,
                                    IUpdateTodoRepository UpdateTodoRepository)
        {
            this._GetTodoRepository = GetTodoRepository;
            this._UpdateTodoRepository = UpdateTodoRepository;
        }

        public async Task<Todo> Execute(UpdateTodoInputModel model, int id)
        {
            var todo = await _GetTodoRepository.GetById(id);

            todo.Title = model.Title ?? todo.Title;
            todo.Done = model.Done ?? todo.Done;

            await _UpdateTodoRepository.Update(todo);

            return todo;
        }
    }
}