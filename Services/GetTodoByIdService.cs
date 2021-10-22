using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTodo.Models;
using MyTodo.Protocols.Db.Repositories;

namespace MyTodo.Services
{
    public class GetTodoByIdService
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