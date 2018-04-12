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
            RegisterCommands(services);
            RegisterEvents(services);
            RegisterNotifications(services);
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
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

        private static void RegisterCommands(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AddBancoCommand, CommandResult>, BancoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateBancoCommand, CommandResult>, BancoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveBancoCommand, CommandResult>, BancoCommandHandler>();

            services.AddScoped<IRequestHandler<AddChequeCommand, CommandResult>, ChequeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateChequeCommand, CommandResult>, ChequeCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveChequeCommand, CommandResult>, ChequeCommandHandler>();
            services.AddScoped<IRequestHandler<BloquearChequeCommand, CommandResult>, ChequeCommandHandler>();
            services.AddScoped<IRequestHandler<RepassarChequeCommand, CommandResult>, ChequeCommandHandler>();
            services.AddScoped<IRequestHandler<CompensarChequeCommand, CommandResult>, ChequeCommandHandler>();
            services.AddScoped<IRequestHandler<DevolverChequeCommand, CommandResult>, ChequeCommandHandler>();
            services.AddScoped<IRequestHandler<SustarChequeCommand, CommandResult>, ChequeCommandHandler>();

            services.AddScoped<IRequestHandler<AddClienteCommand, CommandResult>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClienteCommand, CommandResult>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveClienteCommand, CommandResult>, ClienteCommandHandler>();

            services.AddScoped<IRequestHandler<AddDuplicataCommand, CommandResult>, DuplicataCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateDuplicataCommand, CommandResult>, DuplicataCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveDuplicataCommand, CommandResult>, DuplicataCommandHandler>();
            services.AddScoped<IRequestHandler<PagarDuplicataCommand, CommandResult>, DuplicataCommandHandler>();
            services.AddScoped<IRequestHandler<EstornarDuplicataCommand, CommandResult>, DuplicataCommandHandler>();

            services.AddScoped<IRequestHandler<AddFornecedorCommand, CommandResult>, FornecedorCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateFornecedorCommand, CommandResult>, FornecedorCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveFornecedorCommand, CommandResult>, FornecedorCommandHandler>();

            services.AddScoped<IRequestHandler<AddNotaFiscalCommand, CommandResult>, NotaFiscalCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateNotaFiscalCommand, CommandResult>, NotaFiscalCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveNotaFiscalCommand, CommandResult>, NotaFiscalCommandHandler>();

            services.AddScoped<IRequestHandler<AddProdutoCommand, CommandResult>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProdutoCommand, CommandResult>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProdutoCommand, CommandResult>, ProdutoCommandHandler>();

            services.AddScoped<IRequestHandler<AddOrdemServicoCommand, CommandResult>, OrdemServicoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateOrdemServicoCommand, CommandResult>, OrdemServicoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveOrdemServicoCommand, CommandResult>, OrdemServicoCommandHandler>();
        }

        private static void RegisterEvents(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<AddedChequeEvent>, ChequeEventHandler>();
            services.AddScoped<INotificationHandler<UpdatedChequeEvent>, ChequeEventHandler>();
            services.AddScoped<INotificationHandler<RemovedChequeEvent>, ChequeEventHandler>();
        }

        private static void RegisterNotifications(IServiceCollection services)
        {
            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();
        }

        private static void RegisterIdentityServices(IServiceCollection services)
        {
        }
    }
}
