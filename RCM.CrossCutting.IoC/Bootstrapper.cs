using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ApplicationServices;
using RCM.Application.Mappers;
using RCM.CrossCutting.MediatorServices;
using RCM.Domain.CommandHandlers.BancoCommandHandlers;
using RCM.Domain.CommandHandlers.ChequeCommandHandlers;
using RCM.Domain.CommandHandlers.DuplicataCommandHandlers;
using RCM.Domain.Commands.BancoCommands;
using RCM.Domain.Commands.ChequeCommands;
using RCM.Domain.Commands.DuplicataCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.EventHandlers.ChequeEventHandlers;
using RCM.Domain.Events.ChequeEvents;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using RCM.Infra.Repositories;
using RCM.Infra.UnitOfWork;

namespace RCM.CrossCutting.IoC
{
    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterMiscellaneous(services);
            RegisterRepositories(services);
            RegisterApplicationServices(services);
            RegisterMediatrCommands(services);
            RegisterMediatrEvents(services);
            RegisterMediatrNotifications(services);
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseApplicationService<,>), typeof(BaseApplicationService<,>));
            services.AddScoped<IClienteApplicationService, ClienteApplicationService>();
            services.AddScoped<IDuplicataApplicationService, DuplicataApplicationService>();
            services.AddScoped<IChequeApplicationService, ChequeApplicationService>();
            services.AddScoped<IBancoApplicationService, BancoApplicationService>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IDuplicataRepository, DuplicataRepository>();
            services.AddScoped<IChequeRepository, ChequeRepository>();
            services.AddScoped<IBancoRepository, BancoRepository>();
        }

        private static void RegisterMiscellaneous(IServiceCollection services)
        {
            AutoMapperInitializer.Initialize();

            services.AddSingleton(typeof(IMapper), provider => Mapper.Instance);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
        }

        private static void RegisterMediatrCommands(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<AddDuplicataCommand>, DuplicataCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateDuplicataCommand>, DuplicataCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveDuplicataCommand>, DuplicataCommandHandler>();

            services.AddScoped<INotificationHandler<AddChequeCommand>, ChequeCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateChequeCommand>, ChequeCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveChequeCommand>, ChequeCommandHandler>();

            services.AddScoped<INotificationHandler<AddBancoCommand>, BancoCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateBancoCommand>, BancoCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveBancoCommand>, BancoCommandHandler>();
        }

        private static void RegisterMediatrEvents(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<AddedChequeEvent>, ChequeEventHandler>();
            services.AddScoped<INotificationHandler<UpdatedChequeEvent>, ChequeEventHandler>();
            services.AddScoped<INotificationHandler<RemovedChequeEvent>, ChequeEventHandler>();
        }

        private static void RegisterMediatrNotifications(IServiceCollection services)
        {
            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();
        }
    }
}
