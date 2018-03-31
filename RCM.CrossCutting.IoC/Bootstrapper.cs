using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ApplicationServices;
using RCM.Application.Mappers;
using RCM.CrossCutting.MediatorServices;
using RCM.Domain.CommandHandlers.BancoCommandHandlers;
using RCM.Domain.CommandHandlers.ChequeCommandHandlers;
using RCM.Domain.CommandHandlers.ClienteCommandHandlers;
using RCM.Domain.CommandHandlers.DuplicataCommandHandlers;
using RCM.Domain.CommandHandlers.FornecedorCommandHandlers;
using RCM.Domain.CommandHandlers.NotaFiscalCommandHandlers;
using RCM.Domain.CommandHandlers.ProdutoCommandHandlers;
using RCM.Domain.Commands.BancoCommands;
using RCM.Domain.Commands.ChequeCommands;
using RCM.Domain.Commands.ClienteCommands;
using RCM.Domain.Commands.DuplicataCommands;
using RCM.Domain.Commands.FornecedorCommands;
using RCM.Domain.Commands.NotaFiscalCommands;
using RCM.Domain.Commands.ProdutoCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.EventHandlers.ChequeEventHandlers;
using RCM.Domain.Events.ChequeEvents;
using RCM.Domain.Repositories;
using RCM.Domain.Services.Email;
using RCM.Domain.UnitOfWork;
using RCM.Infra.Data.Repositories;
using RCM.Infra.Data.UnitOfWork;
using RCM.Infra.Services.Email;

namespace RCM.CrossCutting.IoC
{
    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterIntrastructureServices(services);
            RegisterMiscellaneous(services);
            RegisterRepositories(services);
            RegisterApplicationServices(services);
            RegisterMediatrCommands(services);
            RegisterMediatrEvents(services);
            RegisterMediatrNotifications(services);
            RegisterIdentityServices(services);
        }

        private static void RegisterIntrastructureServices(IServiceCollection services)
        {
            services.AddTransient<IEmailDispatcher, EmailDispatcher>();
            services.AddTransient<IEmailGenerator, EmailGenerator>();
        }

        private static void RegisterMiscellaneous(IServiceCollection services)
        {
            AutoMapperInitializer.Initialize();

            services.AddSingleton(typeof(IMapper), provider => Mapper.Instance);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<IChequeRepository, ChequeRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IDuplicataRepository, DuplicataRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseApplicationService<,>), typeof(BaseApplicationService<,>));
            services.AddScoped<IBancoApplicationService, BancoApplicationService>();
            services.AddScoped<IChequeApplicationService, ChequeApplicationService>();
            services.AddScoped<IClienteApplicationService, ClienteApplicationService>();
            services.AddScoped<IDuplicataApplicationService, DuplicataApplicationService>();
            services.AddScoped<IFornecedorApplicationService, FornecedorApplicationService>();
            services.AddScoped<INotaFiscalApplicationService, NotaFiscalApplicationService>();
            services.AddScoped<IProdutoApplicationService, ProdutoApplicationService>();
        }

        private static void RegisterMediatrCommands(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<AddBancoCommand>, BancoCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateBancoCommand>, BancoCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveBancoCommand>, BancoCommandHandler>();

            services.AddScoped<INotificationHandler<AddChequeCommand>, ChequeCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateChequeCommand>, ChequeCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveChequeCommand>, ChequeCommandHandler>();

            services.AddScoped<INotificationHandler<AddClienteCommand>, ClienteCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateClienteCommand>, ClienteCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveClienteCommand>, ClienteCommandHandler>();

            services.AddScoped<INotificationHandler<AddDuplicataCommand>, DuplicataCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateDuplicataCommand>, DuplicataCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveDuplicataCommand>, DuplicataCommandHandler>();
            services.AddScoped<INotificationHandler<PagarDuplicataCommand>, DuplicataCommandHandler>();
            services.AddScoped<INotificationHandler<EstornarDuplicataCommand>, DuplicataCommandHandler>();

            services.AddScoped<INotificationHandler<AddFornecedorCommand>, FornecedorCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateFornecedorCommand>, FornecedorCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveFornecedorCommand>, FornecedorCommandHandler>();

            services.AddScoped<INotificationHandler<AddNotaFiscalCommand>, NotaFiscalCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateNotaFiscalCommand>, NotaFiscalCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveNotaFiscalCommand>, NotaFiscalCommandHandler>();

            services.AddScoped<INotificationHandler<AddProdutoCommand>, ProdutoCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateProdutoCommand>, ProdutoCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveProdutoCommand>, ProdutoCommandHandler>();
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

        private static void RegisterIdentityServices(IServiceCollection services)
        {
        }
    }
}
