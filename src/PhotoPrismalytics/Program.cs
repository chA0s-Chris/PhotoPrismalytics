// Copyright (c) 2025 Christian Flessa. All rights reserved.
// This file is licensed under the MIT license. See LICENSE in the project root for more information.
using PhotoPrismalytics.PhotoPrism;
using Serilog;

Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.Console()
             .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSerilog(Log.Logger);
    builder.AddPhotoPrism();

    var app = builder.Build();
    await app.RunAsync();
}
catch (Exception e)
{
    Log.Fatal(e, "Application start-up failed");
}
finally
{
    await Log.CloseAndFlushAsync();
}
