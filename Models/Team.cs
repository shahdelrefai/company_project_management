namespace CompanyTasksManagement.Models
{
    public class Team
    {
        public int? Id { get; set; }
        public int? DepartementID { get; set;}
        public string? Name { get; set; }
        public int? ManagerID { get; set; }
        public int? LeaderID { get; set; }
        public int? ProjectId { get; set; }
    }
}
