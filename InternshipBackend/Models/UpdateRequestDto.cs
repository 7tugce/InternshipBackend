namespace InternshipBackend.Models
{
    public class UpdateRequestDto
    {
        public required DateTime Date { get; set; }
        public required string SubmittedBy { get; set; }
        public required string Role { get; set; }
        public required string Requirement { get; set; }
        public required string History { get; set; }
        public required string Limitations { get; set; }
        public required string Approach { get; set; }
        public required string Gains { get; set; }
        public string Sketch { get; set; }
    }
}
