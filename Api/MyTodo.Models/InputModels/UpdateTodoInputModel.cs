using System;

namespace MyTodo.Models.InputModels
{
    public class UpdateTodoInputModel
    {
        public string Title { get; set; }
        public bool? Done { get; set; }
        public DateTime? Expire { get; set; }
    }
}