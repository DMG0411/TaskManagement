using Application.UseCases.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases.CommandHandlers
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await _taskRepository.DeleteAsync(request.Id);
        }
    }
}
