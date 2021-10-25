using System;

namespace MyTodo.Exceptions
{
    class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(int id) : base($"Entity with id = {id} not found.")
        {}
    }
}