using MediatR;
using RCM.Domain.Core.Commands;
using System.Threading.Tasks;

namespace RCM.Domain.Core.MediatorServices
{
    public interface IMediatorHandler
    {
        Task<RequestResponse> SendRequest<T>(T request) where T : IRequest<RequestResponse>;
        Task SendCommand<T>(T command) where T : INotification;
        Task Publish<T>(T notification) where T : INotification;
    }
}
