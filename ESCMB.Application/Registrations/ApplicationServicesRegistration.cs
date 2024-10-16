﻿using Core.Application;
using ESCMB.Application.ApplicationServices;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ESCMB.Application.Registrations
{
    /// <summary>
    /// Aqui se deben registrar todas las dependencias de la capa de aplicacion
    /// </summary>
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            /* Automapper */
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            /* EventBus */
            services.AddPublishers();
            services.AddSubscribers();

            /* MediatR*/
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<ICommandQueryBus, MediatrCommandQueryBus>();

            /* Application Services */
            services.AddScoped<IDummyEntityApplicationService, DummyEntityApplicationService>();
            services.AddScoped<ICustomerApplicationService, CustomerEntityApplicationService>();
            return services;
        }

        private static IServiceCollection AddPublishers(this IServiceCollection services)
        {
            //Aqui se registran los handlers que publican en el bus de eventos
            return services;
        }

        private static IServiceCollection AddSubscribers(this IServiceCollection services)
        {
            //Aqui se registran los handlers que se suscriben al bus de eventos
            return services;
        }
    }
}
