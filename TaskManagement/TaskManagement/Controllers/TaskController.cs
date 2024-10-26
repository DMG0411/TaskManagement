using Application.DTOs;
using Application.UseCases.Commands;
using Application.UseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.Controllers
{
    [Route("api/v1/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateTask(CreateTaskCommand command)
        {
            var taskId = await _mediator.Send(command);
            return Created(nameof(TaskDto), taskId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTaskById(Guid id)
        {
            return await _mediator.Send(new GetTaskByIdQuery(id));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTask(TaskDto task)
        {
            await _mediator.Send(new UpdateTaskCommand(task));
            return Ok(task);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTasks()
        {
            var tasks = await _mediator.Send(new GetAllTasksQuery());
            return Ok(tasks);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(Guid id)
        {
            await _mediator.Send(new DeleteTaskCommand(id));
            return NoContent();
        }
    }
}
