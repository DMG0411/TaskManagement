using Application.DTOs;
using MediatR;

namespace Application.UseCases.Queries
{
    public class GetTaskByIdQuery : IRequest<TaskDto>
    {
        public Guid Id { get; set; }

        public GetTaskByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
