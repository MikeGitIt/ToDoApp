namespace ToDoApp.AppServices.Dtos
{
    public class TodoFilterDto
    {
        public int? Id { get; set; }
        public string Text { get; set; }

        public bool? IsCompleted { get; set; }
    }
}
