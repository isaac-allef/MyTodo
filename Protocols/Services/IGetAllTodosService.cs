using System.Collections.Generic;
using System.Threading.Tasks;
using MyTodo.InputModels;
using MyTodo.Models;

namespace MyTodo.Protocols.Services
{
    public interface IGetAllTodosService
    {
        Task<List<Todo>> Execute(GetAllTodosInputModel model);
    }
}