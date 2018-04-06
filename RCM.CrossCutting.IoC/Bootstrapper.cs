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
using RCM.Domain.CommandHandlers.OrdemServicoCommandHandlers;
using RCM.Domain.CommandHandlers.ProdutoCommandHandlers;
using RCM.Domain.Commands.BancoCommands;
using RCM.Domain.Commands.ChequeCommands;
using RCM.Domain.Commands.ClienteCommands;
using RCM.Domain.Commands.DuplicataCommands;
using RCM.Domain.Commands.FornecedorCommands;
using RCM.Domain.Commands.NotaFiscalCommands;
using RCM.Domain.Commands.OrdemServicoCommands;
using RCM.Domain.Commands.ProdutoCommands;
using RCM.Domain.Core.Commands;
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
            services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();
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
            services.AddScoped<IOrdemServicoApplicationService, OrdemServicoApplicationService>();
            services.AddScoped<IProdutoApplicationService, ProdutoApplicationService>();
        }

        private static void RegisterMediatrCommands(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AddBancoCommand, RequestResponse>, BancoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateBancoCommand, RequestResponse>, BancoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveBancoCommand, RequestResponse>, BancoCommandHandler>();

            services.AddScoped<IRequestHandler<AddChequeCommand, RequestResponse>, ChequeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateChequeCommand, RequestResponse>, ChequeCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveChequeCommand, RequestResponse>, ChequeCommandHandler>();

            services.AddScoped<IRequestHandler<AddClienteCommand, RequestResponse>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClienteCommand, RequestResponse>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveClienteCommand, RequestResponse>, ClienteCommandHandler>();

            services.AddScoped<IRequestHandler<AddDuplicataCommand, RequestResponse>, DuplicataCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateDuplicataCommand, RequestResponse>, DuplicataCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveDuplicataCommand, RequestResponse>, DuplicataCommandHandler>();
            services.AddScoped<IRequestHandler<PagarDuplicataCommand, RequestResponse>, DuplicataCommandHandler>();
            services.AddScoped<IRequestHandler<EstornarDuplicataCommand, RequestResponse>, DuplicataCommandHandler>();

            services.AddScoped<IRequestHandler<AddFornecedorCommand, RequestResponse>, FornecedorCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateFornecedorCommand, RequestResponse>, FornecedorCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveFornecedorCommand, RequestResponse>, FornecedorCommandHandler>();

            services.AddScoped<IRequestHandler<AddNotaFiscalCommand, RequestResponse>, NotaFiscalCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateNotaFiscalCommand, RequestResponse>, NotaFiscalCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveNotaFiscalCommand, RequestResponse>, NotaFiscalCommandHandler>();

            services.AddScoped<IRequestHandler<AddProdutoCommand, RequestResponse>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProdutoCommand, RequestResponse>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProdutoCommand, RequestResponse>, ProdutoCommandHandler>();

            services.AddScoped<IRequestHandler<AddOrdemServicoCommand, RequestResponse>, OrdemServicoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateOrdemServicoCommand, RequestResponse>, OrdemServicoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveOrdemServicoCommand, RequestResponse>, OrdemServicoCommandHandler>();
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
