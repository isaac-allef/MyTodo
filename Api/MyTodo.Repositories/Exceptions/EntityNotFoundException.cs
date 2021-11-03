using System;

namespace MyTodo.Repositories.Exceptions
{
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(int id) : base($"Entity with id = {id} not found.")
        {}
    }
}