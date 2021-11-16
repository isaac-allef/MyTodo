using System.Threading.Tasks;
using MyTodo.Facades.Interfaces;
using MyTodo.Models.EntityModels;
using MyTodo.Models.InputModels;
using MyTodo.Services.Interfaces;

namespace MyTodo.Facades
{
    public class TodoFacade : ITodoFacade
    {
        private readonly IEnqueueJobService _enqueueJobService;
        private readonly ISendEmailService _sendEmailService;
        private readonly ICreateTodoService _createTodoService;
        private readonly IDeleteTodoService _deleteTodoService;
        private readonly IUpdateTodoService _updateTodoService;

        public TodoFacade(IEnqueueJobService enqueueJobService,
                        ISendEmailService sendEmailService,
                        ICreateTodoService createTodoService,
                        IUpdateTodoService updateTodoService,
                        IDeleteTodoService deleteTodoService)
        {
            this._enqueueJobService = enqueueJobService;
            this._sendEmailService = sendEmailService;
            this._createTodoService = createTodoService;
            this._updateTodoService = updateTodoService;
            this._deleteTodoService = deleteTodoService;
        }
        
        public async Task<Todo> Create(CreateTodoInputModel model)
        {
            var todoCreated = await _createTodoService.Execute(model);

            await _enqueueJobService.Execute("CREATE", () => _sendEmailService.Execute(
                "curinga@hahaha.com",
                new string[2] {"bruce@batman.com", "alfred@batman.com"},
                "Create",
                $"Todo with id = {todoCreated.Id} was created."
            ));
            
            return todoCreated;
        }

        public async Task<Todo> Delete(int id)
        {
            var todoDeleted = await _deleteTodoService.Execute(id);

            await _enqueueJobService.Execute("CREATE", () => _sendEmailService.Execute(
                "curinga@hahaha.com",
                new string[2] {"bruce@batman.com", "alfred@batman.com"},
                "Delete",
                $"Todo with id = {todoDeleted.Id} was deleted."
            ));

            return todoDeleted;
        }

        public async Task<Todo> Update(UpdateTodoInputModel model, int id)
        {
            var todoUpdated = await _updateTodoService.Execute(model, id);

            await _enqueueJobService.Execute("CREATE", () => _sendEmailService.Execute(
                "curinga@hahaha.com",
                new string[2] {"bruce@batman.com", "alfred@batman.com"},
                "Update",
                $"Todo with id = {todoUpdated.Id} was updated."
            ));
            
            return todoUpdated;
        }
    }
}
