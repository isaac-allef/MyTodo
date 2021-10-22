using System.ComponentModel.DataAnnotations;

namespace MyTodo.InputModels
{
    public class CreateTodoInputModel
    {
        [Required]
        public string Title { get; set; }
    }
}