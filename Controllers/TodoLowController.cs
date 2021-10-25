using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTodo.InputModels;
using MyTodo.Protocols.Services;

namespace MyTodo.Controllers
{
    [ApiController]
    [Route(template: "v2")]
    public class TodoLowController : ControllerBase
    {
        [HttpGet]
        [Route(template: "todos")]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] IGetAllTodosService GetAllTodosService
        )
        {
            try
            {
                var todos = await GetAllTodosService.Execute();

                return Ok(todos);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err);
            }
        }

        [HttpGet]
        [Route(template: "todos/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] IGetTodoByIdService GetTodoByIdService,
            [FromRoute] int id
        )
        {
            try
            {
                var todo = await GetTodoByIdService.Execute(id);

                return todo == null 
                    ? NotFound() : Ok(todo);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err);
            }

        }

        [HttpPost(template: "todos")]
        public async Task<IActionResult> PostAsync(
            [FromServices] ICreateTodoService CreateTodoService,
            [FromBody] CreateTodoInputModel model
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var todoCreated = await CreateTodoService.Execute(model);

                return Created(uri: $"v2/todos/{todoCreated.Id}", todoCreated);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err);
            }
        }

        [HttpPut(template: "todos/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] IUpdateTodoService UpdateTodoService,
            [FromBody] UpdateTodoInputModel model,
            [FromRoute] int id
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var todoUpdated = await UpdateTodoService.Execute(model, id);
                
                if (todoUpdated == null)
                {
                    return NotFound();
                }

                return Ok(todoUpdated);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err);
            }
        }

        [HttpDelete(template: "todos/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] IDeleteTodoService DeleteTodoService,
            [FromRoute] int id
        )
        {
            try
            {
                var todoDeleted = await DeleteTodoService.Execute(id);
                
                if (todoDeleted == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err);
            }
        }
    }
}