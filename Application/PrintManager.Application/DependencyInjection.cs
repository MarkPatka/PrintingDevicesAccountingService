﻿using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace PrintManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        ///...
        return services;
    }
}
