namespace MedicineManager.Models
{
    public class ReponseDto
    {
        public string Message { get; set; }
        public bool isSuccess { get; set; }
        public object? Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
