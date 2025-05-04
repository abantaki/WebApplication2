using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly ProjectService _projectService;

        public IndexModel(ProjectService projectService)
        {
            _projectService = projectService;
        }

        public IList<Project> Projects { get; set; } = new List<Project>();

        [BindProperty(SupportsGet = true)]
        public ProjectStatus? Status { get; set; }

        [BindProperty]
        public Project Project { get; set; } = new Project();

        public int AllCount { get; set; }
        public int StartedCount { get; set; }
        public int CompletedCount { get; set; }

        public async Task OnGetAsync()
        {
            var allProjects = await _projectService.GetProjectsByStatusAsync(null);
            Projects = Status.HasValue
                ? allProjects.Where(p => p.Status == Status.Value)
                              .OrderByDescending(p => p.CreatedAt)
                              .ToList()
                : allProjects.OrderByDescending(p => p.CreatedAt).ToList();

            AllCount = allProjects.Count;
            StartedCount = allProjects.Count(p => p.Status == ProjectStatus.Started);
            CompletedCount = allProjects.Count(p => p.Status == ProjectStatus.Completed);
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync(); 
                return Page();
            }

            
            Project.CreatedAt = DateTime.UtcNow;

            await _projectService.CreateProjectAsync(Project);
            return RedirectToPage(); 
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project != null)
            {
                await _projectService.DeleteProjectAsync(id);
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetEditPartialAsync(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return Partial("_EditProjectPartial", project);
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Partial("_EditProjectPartial", Project);
            }

            await _projectService.UpdateProjectAsync(Project);
            return RedirectToPage();
        }
    }
}
