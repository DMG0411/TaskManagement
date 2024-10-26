using MediatR;

namespace Application.UseCases.Commands
{
    public class CreateTaskCommand : IRequest<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }
    }
}
