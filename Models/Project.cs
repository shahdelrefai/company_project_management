namespace CompanyTasksManagement.Models
{
    public class Project
    {
        public int? Id { get; set; }
        public int? TeamID { get; set; }
        public string? Name { get; set; }
        public string? Summary { get; set; }
        public string? Details { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
