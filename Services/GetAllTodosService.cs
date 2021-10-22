using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyTodo.Models;
using MyTodo.Protocols.Db.Repositories;

namespace MyTodo.Services
{
    public class GetAllTodosService
    {
        private IGetAllTodosRepository _GetAllTodosRepository;
        public GetAllTodosService(IGetAllTodosRepository GetAllTodosRepository)
        {
            this._GetAllTodosRepository = GetAllTodosRepository;
        }

        public async Task<List<Todo>> Execute()
        {
            var todos = await _GetAllTodosRepository.GetAll();

            return todos;
        }
    }
}