using Application.DTOs;
using Application.UseCases.Queries;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases.QueryHandlers
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetAllTasksQueryHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }
    }
}
