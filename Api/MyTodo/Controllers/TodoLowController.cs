using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTodo.Models;
using MyTodo.Models.InputModels;
using MyTodo.Services.Interfaces;

namespace MyTodo.Controllers
{
    [ApiController]
    [Route(template: "v2")]
    public class TodoLowController : ControllerBase
    {
        [HttpGet]
        [Route(template: "todos")]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] IGetAllTodosService GetAllTodosService,
            [FromQuery] GetAllTodosInputModel model
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var todos = await GetAllTodosService.Execute(model);

            Response.Headers.Add(Constants.TOTAL_ITEMS_COUNT_HEADER, todos.Count.ToString());

            return Ok(todos);
        }

        [HttpGet]
        [Route(template: "todos/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] IGetTodoByIdService GetTodoByIdService,
            [FromRoute] int id
        )
        {
            var todo = await GetTodoByIdService.Execute(id);

            return Ok(todo);

        }

        [HttpPost(template: "todos")]
        public async Task<IActionResult> PostAsync(
            [FromServices] ICreateTodoService CreateTodoService,
            [FromBody] CreateTodoInputModel model
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var todoCreated = await CreateTodoService.Execute(model);

            return Created(uri: $"v2/todos/{todoCreated.Id}", todoCreated);
        }

        [HttpPut(template: "todos/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] IUpdateTodoService UpdateTodoService,
            [FromBody] UpdateTodoInputModel model,
            [FromRoute] int id
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var todoUpdated = await UpdateTodoService.Execute(model, id);

            return Ok(todoUpdated);
        }

        [HttpDelete(template: "todos/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] IDeleteTodoService DeleteTodoService,
            [FromRoute] int id
        )
        {
            var todoDeleted = await DeleteTodoService.Execute(id);

            return Ok(todoDeleted);
        }
    }
}