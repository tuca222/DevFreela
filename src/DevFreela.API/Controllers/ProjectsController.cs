using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;
        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

        //api/projects GET
        [HttpGet]
        public IActionResult Get(string query)
        {
            //Buscar todos ou filtrar
            var projects = _projectService.GetAll(query);

            return Ok(projects);
        }

        //api/projects/3 GetById
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if (project == null)
                return NotFound();
            
            return Ok();
        }

        //api/projects POST
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            if (command.Title.Length > 50)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new {id = id}, command);
        }

        //api/projects/2 PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 200)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        //api/projects/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteProjectCommand command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        //api/projects/2/comments
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        //api/projetcs/1/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            StartProjectCommand command = new StartProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        //api/projects/1/finish
        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            FinishProjectCommand command = new FinishProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
