using MediatR;
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

        public async Task SendCommand<T>(T command) where T : INotification
        {
            await _mediator.Publish(command);
        }

        public async Task Publish<T>(T notification) where T : INotification
        {
            await _mediator.Publish(notification);
        }
    }
}
