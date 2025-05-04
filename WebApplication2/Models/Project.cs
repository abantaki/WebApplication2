using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public enum ProjectStatus
    {
        Started,
        Completed
    }

    public class Project
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Project name is required.")]
        [Display(Name = "Project Name")]
        public string? ProjectName { get; set; }

        [Required(ErrorMessage = "Client name is required.")]
        [Display(Name = "Client Name")]
        public string? ClientName { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Budget is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Budget must be a positive number.")]
        public decimal Budget { get; set; }

        [Display(Name = "Status")]
        public ProjectStatus Status { get; set; } = ProjectStatus.Started;

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
    }
}
