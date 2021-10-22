using System;
using System.Threading.Tasks;
using MyTodo.InputModels;
using MyTodo.Models;
using MyTodo.Protocols.Db.Repositories;

namespace MyTodo.Services
{
    public class CreateTodoService
    {
        private ICreateTodoRepository _CreateTodoRepository;
        public CreateTodoService(ICreateTodoRepository CreateTodoRepository)
        {
            this._CreateTodoRepository = CreateTodoRepository;
        }

        public async Task<Todo> Execute(CreateTodoInputModel model)
        {
            var todo = new Todo
            {
                Date = DateTime.Now,
                Done = false,
                Title = model.Title
            };

            await _CreateTodoRepository.Create(todo);

            return todo;
        }
    }
}