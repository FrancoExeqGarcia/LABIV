namespace TP_LABIV.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public bool State;

        public ICollection<TodoItem> TodoItem { get; set; }
    }
}
