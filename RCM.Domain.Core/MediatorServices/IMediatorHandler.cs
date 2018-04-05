using MediatR;
using System.Threading.Tasks;

namespace RCM.Domain.Core.MediatorServices
{
    public interface IMediatorHandler
    {
        Task<string> SendRequest<T>(T request) where T : IRequest<string>;
        Task SendCommand<T>(T command) where T : INotification;
        Task Publish<T>(T notification) where T : INotification;
    }
}
