using Application.UseCases.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases.CommandHandlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Domain.Entities.Task
            {
                Title = request.Title,
                Description = request.Description,
                Deadline = request.Deadline
            };

           return await _taskRepository.AddAsync(task);
        }
    }
}
