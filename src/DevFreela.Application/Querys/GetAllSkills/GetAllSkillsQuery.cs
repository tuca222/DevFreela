using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Querys.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
    }
}
