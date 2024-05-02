namespace TP_LABIV.Data.Entities
{
    public class TodoItem
    {
        public int ToDoItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User User { get; set; }


    }
}
