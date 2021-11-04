using System.Threading.Tasks;
using MyTodo.Models.InputModels;
using MyTodo.Models.EntityModels;
using MyTodo.Repositories.Interfaes.Db;
using MyTodo.Services.Interfaces;

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

            todo.setTitle(model.Title ?? todo.Title);
            todo.setDone(model.Done ?? todo.Done);
            todo.setExpire(model.Expire ?? todo.Expire);

            await _UpdateTodoRepository.Update(todo);

            return todo;
        }
    }
}