namespace ToDoApp.Domain.Filters
{
    public class TodoFilter
    {
        public int? Id { get; set; }
        public string Text { get; set; }

        public bool? IsCompleted { get; set; }
    }
}
