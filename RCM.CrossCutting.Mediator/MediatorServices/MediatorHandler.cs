using System.Threading.Tasks;
using MediatR;
using RCM.Domain.Core.MediatorServices;

namespace RCM.CrossCutting.MediatorServices
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Publish<T>(T notification) where T : INotification
        {
            await _mediator.Publish(notification);
        }

        public async Task SendCommand<T>(T notification) where T : INotification
        {
            await _mediator.Publish(notification);
        }
    }
}
