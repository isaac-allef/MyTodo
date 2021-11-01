using System.Collections.Generic;
using System.Threading.Tasks;
using MyTodo.InputModels;
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

        public async Task<List<Todo>> Execute(GetAllTodosInputModel model)
        {
            const int PER_PAGE = 5;
            const int PAGE = 1;

            string search = model.search ?? "";
            string orderBy = model.orderBy ?? "";
            string direction = model.direction ?? "";
            int per_page = model.per_page ?? PER_PAGE;
            int page = model.page ?? PAGE;

            var todos = await _GetAllTodosRepository.GetAll(search,
                                                            orderBy,
                                                            direction,
                                                            per_page,
                                                            page);

            return todos;
        }
    }
}