namespace WebApplication2.Models
{
    public enum ProjectStatus
    {
        Started,
        Completed
    }

    public class Project
    {
        public int Id { get; set; } //  This MUST exist and be public
        public string? ProjectName { get; set; }
        public string? ClientName { get; set; }
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.Started;

    }
}
