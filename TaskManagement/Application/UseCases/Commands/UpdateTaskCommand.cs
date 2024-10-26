using Application.DTOs;
using MediatR;

namespace Application.UseCases.Commands
{
    public class UpdateTaskCommand : IRequest
    {
        public TaskDto Task { get; set; }

        public UpdateTaskCommand(TaskDto task)
        {
            Task = task;
        }
    }
}
