namespace Todo.Application.DTOs
{
    public class StatusResponse
    {
        public Guid Id { get; set; } = new Guid();

        public string Status { get; set; } = string.Empty;
    }
}
