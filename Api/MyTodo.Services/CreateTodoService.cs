using System;
using System.Threading.Tasks;
using MyTodo.Models.InputModels;
using MyTodo.Models.EntityModels;
using MyTodo.Repositories.Interfaes.Db;
using MyTodo.Services.Interfaces;

namespace MyTodo.Services
{
    public class CreateTodoService : ICreateTodoService
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