using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_LABIV.Data.Entities;
using TP_LABIV.Services.Interfaces;
using TP_LABIV.Data.Models;

namespace TP_LABIV.Controllers
{
    [Route("api/TodoItem")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;
        private readonly IUserService _userService;
        public TodoItemController(ITodoItemService todoItemService, IUserService userService)
        {
            _todoItemService = todoItemService;
            _userService = userService;
        }
        [HttpPost]
        public IActionResult CreateTodoItem([FromBody] ItemDto itemDto)
        {
            // Verificar si el usuario existe
            var user = _userService.GetUserById(itemDto.UserId);
            if (user == null)
            {
                return BadRequest($"El usuario con ID {itemDto.UserId} no existe.");
            }

            var todoItem = new TodoItem
            {
                Title = itemDto.Title,
                Description = itemDto.Description,
                ToDoItemId = itemDto.UserId // Asignar el UserId del DTO al nuevo TodoItem
            };

            int todoItemId = _todoItemService.CreateItem(todoItem);

            return Ok(todoItemId);
        }


        [HttpGet("GetAllItems")]
        public IActionResult GetAllItems()
        {
            var res = _todoItemService.GetItems();
            return Ok(res);
        }

        [HttpGet("GetTodosByUser/{userId}")]
        public IActionResult GetTodosByUser(int userId)
        {
            var todos = _todoItemService.GetItemsByUserId(userId);
            return Ok(todos);
        }

        [HttpPut("UpdateTodoItem/{todoItemId}")]
        public IActionResult UpdateTodoItem([FromRoute] int todoItemId, [FromBody] ItemDto itemDto)
        {
            var todoItem = new TodoItem
            {
                ToDoItemId = todoItemId,
                Title = itemDto.Title,
                Description = itemDto.Description,
            };

            int updatedItemId = _todoItemService.UpdateItem(todoItem);

            if (updatedItemId == 0)
            {
                return NotFound($"Elemento de lista de tareas con Id {todoItemId} no encontrado");
            }

            return Ok(updatedItemId);
        }

        [HttpDelete("DeleteTodoItem/{todoItemId}")]
        public IActionResult DeleteTodoItem([FromRoute] int todoItemId)
        {
            _todoItemService.DeleteItem(todoItemId);
            return Ok();
        }
    }
}

