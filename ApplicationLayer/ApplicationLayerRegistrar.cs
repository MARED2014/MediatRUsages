using ApplicationLayer.Features.Holidays.Rules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ApplicationLayer;

public static class ApplicationLayerRegistrar
{
    public static void RegisterApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(DuplicateHolidayNameBehavior<,>));
        });
    }
}
