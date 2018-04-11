using MediatR;
using RCM.Domain.Core.Commands;
using System.Threading.Tasks;

namespace RCM.Domain.Core.MediatorServices
{
    public interface IMediatorHandler
    {
        Task<CommandResult> SendCommand<T>(T command) where T : IRequest<CommandResult>;
        Task Publish<T>(T notification) where T : INotification;
    }
}
