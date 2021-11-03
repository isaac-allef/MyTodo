namespace MyTodo.Models.InputModels
{
    public class GetAllTodosInputModel
    {
        public string search { get; set; }
        public string orderBy { get; set; }
        public string direction { get; set; }
        public int? per_page { get; set; }
        public int? page { get; set; }
    }
}