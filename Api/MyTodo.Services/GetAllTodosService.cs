using System.Collections.Generic;
using System.Threading.Tasks;
using MyTodo.Models.InputModels;
using MyTodo.Models.EntityModels;
using MyTodo.Repositories.Interfaes.Db;
using MyTodo.Services.Interfaces;
using MyTodo.Models;

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
            string search = model.search ?? Constants.SEARCH_DEFAULT_PARAM;
            string orderBy = model.orderBy ?? Constants.ORDER_BY_DEFAULT_PARAM;
            string direction = model.direction ?? Constants.DIRECTION_DEFAULT_PARAM;
            int per_page = model.per_page ?? Constants.PER_PAGE_DEFAULT_PARAM;
            int page = model.page ?? Constants.PAGE_DEFAULT_PARAM;

            var todos = await _GetAllTodosRepository.GetAll(search,
                                                            orderBy,
                                                            direction,
                                                            per_page,
                                                            page);

            return todos;
        }
    }
}