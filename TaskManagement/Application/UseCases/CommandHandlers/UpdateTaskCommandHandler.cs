using Application.UseCases.Commands;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases.CommandHandlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public UpdateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            await _taskRepository.UpdateAsync(_mapper.Map<Domain.Entities.Task>(request.Task));
        }
    }
}
