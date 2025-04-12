// Copyright (c) 2025 Christian Flessa. All rights reserved.
// This file is licensed under the MIT license. See LICENSE in the project root for more information.
namespace PhotoPrismalytics.PhotoPrism;

using Microsoft.Extensions.Options;

public static class PhotoPrismWebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddPhotoPrism(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<PhotoPrismSettings>(builder.Configuration.GetSection("PhotoPrism"));

        builder.Services.AddSingleton<IPhotoPrismClientFactory, PhotoPrismClientFactory>();
        builder.Services.AddTransient<IPhotoPrismClient>(serviceProvider =>
        {
            var settings = serviceProvider.GetRequiredService<IOptions<PhotoPrismSettings>>().Value;

            var token = settings.BearerToken ?? throw new InvalidOperationException("Bearer token is required.");
            var tokenProvider = new PhotoPrismBearerTokenProvider(token);

            var factory = serviceProvider.GetRequiredService<IPhotoPrismClientFactory>();
            return factory.CreatePhotoPrismClient(settings.BaseUrl, tokenProvider);
        });

        return builder;
    }
}
