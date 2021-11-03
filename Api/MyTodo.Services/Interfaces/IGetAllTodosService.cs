using System.Collections.Generic;
using System.Threading.Tasks;
using MyTodo.Models.InputModels;
using MyTodo.Models.EntityModels;

namespace MyTodo.Services.Interfaces
{
    public interface IGetAllTodosService
    {
        Task<List<Todo>> Execute(GetAllTodosInputModel model);
    }
}