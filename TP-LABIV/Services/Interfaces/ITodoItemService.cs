using System.Collections.Generic;
using TP_LABIV.Data.Entities;

namespace TP_LABIV.Services.Interfaces
{
    public interface ITodoItemService
    {
        int CreateItem(TodoItem item);
        void DeleteItem(int idItem);
        List<TodoItem> GetItems();
        List<TodoItem> GetItemsByUserId(int userId);
        int UpdateItem(TodoItem item);
    }
}
