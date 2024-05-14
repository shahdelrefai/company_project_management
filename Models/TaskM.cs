namespace CompanyTasksManagement.Models
{
    public class TaskM
    {
        public int? Id { get; set; } = null;
        public int? ProjectID { get; set; } = null;
        public string? Name { get; set; } = null;
        public string? Summary { get; set; } = null;
        public string? Details { get; set; } = null;
        public string? Notes { get; set; } = null;
        public int? AssignBy { get; set; } = null;
        public int? AssignFor { get; set;} = null;
        public DateTime? SetForDate { get; set; } = null;
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set;} = null;
        public DateTime? Deadline { get; set;} = null;
    }
}
