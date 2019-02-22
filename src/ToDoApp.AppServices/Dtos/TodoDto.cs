namespace ToDoApp.AppServices.Dtos
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public bool IsCompleted { get; set; }
    }
}
