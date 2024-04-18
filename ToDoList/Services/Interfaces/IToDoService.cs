using ErrorOr;
using System.Collections.Generic;
using TODOLIST.Data.Entities;

namespace TODOLIST.Services.Interfaces
{
    public interface IToDoService
    {
        List<ToDoItem> GetAllToDos();
        ToDoItem? GetTodoById(int todoId);
        ToDoItem CreateTodo(ToDoItem toDo);
        ToDoItem? UpdateTodo(int todoId, ToDoItem updatedTodo);
        bool DeleteTodo(int todoId);
    }
}
