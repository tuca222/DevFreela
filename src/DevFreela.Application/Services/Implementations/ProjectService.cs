using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewProjectInputModel projectCreateInputModel)
        {
            Project project = new Project(projectCreateInputModel.Title, projectCreateInputModel.Description, projectCreateInputModel.IdClient, projectCreateInputModel.IdFreelancer, projectCreateInputModel.TotalCost);

            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();

            return project.Id;
        }

        public void CreateComment(NewCommentInputModel commentCreateInputModel)
        {
            ProjectComment comment = new ProjectComment(commentCreateInputModel.Content, commentCreateInputModel.IdProject, commentCreateInputModel.IdUser);

            _dbContext.ProjectComments.Add(comment);

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Project project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Cancel();

            _dbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            Project project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Finish();

            _dbContext.SaveChanges();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            Project project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
                return null;

            return new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt
                );
        }
        public void Start(int id)
        {
            Project project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Start();

            _dbContext.SaveChanges();
        }
        public void Update(UpdateProjectInputModel projectUpdateInputModel)
        {
            Project project = _dbContext.Projects.SingleOrDefault(p => p.Id == projectUpdateInputModel.Id);

            project.Update(projectUpdateInputModel.Title, projectUpdateInputModel.Description, projectUpdateInputModel.TotalCost);

            _dbContext.SaveChanges();
        }
    }
}
