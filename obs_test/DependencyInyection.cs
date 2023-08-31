﻿using Microsoft.Extensions.DependencyInjection;
using obs_test.Application.Services;

namespace obs_test;

public static class DependencyInyection
{
    public static IServiceCollection AddServices(this IServiceCollection services) => services.AddSingleton<IRobotSimulatorService, RobotSimulatorService>();
}