using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace CompanyTasksManagement.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Type { get; set; }
        public string? CompanyID { get; set; }
        public int? TeamID { get; set; }
        public int? Access { get; set; }
        public string? AccountType { get; set; }
        public int? Authority { get; set; }
        public List<TaskM>? Tasks = new List<TaskM>();
    }
}
