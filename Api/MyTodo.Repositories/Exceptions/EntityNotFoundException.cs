using System.Net;
using MyTodo.Models;

namespace MyTodo.Repositories.Exceptions
{
    public class EntityNotFoundException : ApplicationExceptionStatusCode
    {
        public EntityNotFoundException(int id) : base($"Entity with id = {id} not found.", 
                                                        HttpStatusCode.NotFound)
        {}
    }
}