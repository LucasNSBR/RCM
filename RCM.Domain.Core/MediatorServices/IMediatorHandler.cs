using MediatR;
using System.Threading.Tasks;

namespace RCM.Domain.Core.MediatorServices
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T notification) where T : INotification;
        Task Publish<T>(T notification) where T : INotification;
    }
}
