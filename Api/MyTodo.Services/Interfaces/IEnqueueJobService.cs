using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyTodo.Services.Interfaces
{
    public interface IEnqueueJobService
    {
        Task Execute(string identifier, Expression<Action> action);
    }
}