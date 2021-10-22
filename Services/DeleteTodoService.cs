using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTodo.Data;
using MyTodo.Models;
using MyTodo.Protocols.Db.Repositories;

namespace MyTodo.Services
{
    public class DeleteTodoService
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
            
            if (todo == null)
            {
                return null;
            }

            await _DeleteTodoRepository.Delete(todo);

            return todo;
        }
    }
}