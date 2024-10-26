namespace Application.DTOs
{
    public class TaskDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
