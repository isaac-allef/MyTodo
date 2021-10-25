using System.Collections.Generic;
using System.Threading.Tasks;
using MyTodo.Models;
using MyTodo.Protocols.Db.Repositories;
using MyTodo.Protocols.Services;

namespace MyTodo.Services
{
    public class GetAllTodosService : IGetAllTodosService
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