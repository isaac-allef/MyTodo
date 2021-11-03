using System.ComponentModel.DataAnnotations;

namespace MyTodo.Models.InputModels
{
    public class CreateTodoInputModel
    {
        [Required]
        public string Title { get; set; }
    }
}