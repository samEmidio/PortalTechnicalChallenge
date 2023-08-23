using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PortalTechnicalChallenge.Application.Interfaces;
using PortalTechnicalChallenge.Application.Validation.User;
using PortalTechnicalChallenge.Domain.Core.Bus;
using PortalTechnicalChallenge.Domain.Core.Notifications;
using PortalTechnicalChallenge.Domain.Interfaces;
using PortalTechnicalChallenge.Infra.CrossCutting.Bus;
using PortalTechnicalChallenge.Infra.Data.Context;
using PortalTechnicalChallenge.Infra.Data.Repositories;
using PortalTechnicalChallenge.Infra.Data.UnitOfWork;
using TechnicalChallenge.Application.Services;

namespace PortalTechnicalChallenge.Infra.CrossCutting.IoC
{

    /// <summary>
    /// injecta servicos e repos
    /// </summary>

    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IUserAppService, UserAppService>();



            // Application DTO Validators
            services.AddTransient<CreateUserValidation>();
            services.AddTransient<UpdateUserValidation>();



            // Domain
            services.AddScoped<IUserRepository, UserRepository>();
            


            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<PortalTechnicalChallengeContext>();

        }
    }
}