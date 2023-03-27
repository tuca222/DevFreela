using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASP NET Core 1", "Descrição 1", 1, 1, 10000),
                new Project("Meu projeto ASP NET Core 2", "Descrição 2", 1, 1, 20000),
                new Project("Meu projeto ASP NET Core 3", "Descrição 3", 1, 1, 30000)
            };

            Users = new List<User>
            {
                new User("Usuário 1", "tucaa222@gmail.com", new DateTime(1999, 12, 27)),
                new User("Usuário 2", "EMAIL 2", new DateTime(1800, 12, 27)),
                new User("Usuário 3", "EMAIL 3", new DateTime(1700, 12, 27))

            };

            Skills = new List<Skill>
            {
                new Skill(".NET CORE"),
                new Skill("C#"),
                new Skill("PYTHON")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}
