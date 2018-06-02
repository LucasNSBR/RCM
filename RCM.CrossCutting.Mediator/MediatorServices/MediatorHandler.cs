using MediatR;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using System.Threading.Tasks;

namespace RCM.CrossCutting.MediatorServices
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CommandResult> SendCommand<T>(T command) where T : IRequest<CommandResult>
        {
            return await _mediator.Send(command);
        }

        public async Task PublishEvent<T>(T notification) where T : INotification
        {
            await _mediator.Publish(notification);
        }
    }
}
