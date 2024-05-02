using TP_LABIV.Data.Entities;
using TP_LABIV.Services.Interfaces;

namespace TP_LABIV.Services.Implementations
{
    public class ToDoService : ITodoItemService
    {
        private readonly TodoContext _context;
        public ToDoService(TodoContext context)
        {
            _context = context;
        }

        public int CreateItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();
            return item.ToDoItemId;
        }

        public void DeleteItem(int idItem)
        {
            var item = _context.TodoItems.FirstOrDefault(x => x.ToDoItemId == idItem);
            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
        }


        public TodoItem GetById(int id)
        {
            return _context.TodoItems.FirstOrDefault(i => i.ToDoItemId == id);
        }

        public List<TodoItem> GetItems()
        {
            return _context.TodoItems.ToList();
        }

        public int UpdateItem(TodoItem item)
        {
            var existingItem = _context.TodoItems.FirstOrDefault(i => i.ToDoItemId == item.ToDoItemId);
            if (existingItem == null)
            {
                return 0; // Opcional: puedes lanzar una excepción o manejar de otra forma si el ítem no existe
            }

            existingItem.Title = item.Title;
            existingItem.Description = item.Description;

            _context.Update(existingItem);
            _context.SaveChanges();
            return existingItem.ToDoItemId; // Devolver el ID del ítem actualizado
        }


        public List<TodoItem> GetItemsByUserId(int userId)
        {
            return _context.TodoItems.Where(i => i.ToDoItemId == userId).ToList();
        }
    }
}
