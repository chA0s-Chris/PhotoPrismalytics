// Copyright (c) 2025 Christian Flessa. All rights reserved.
// This file is licensed under the MIT license. See LICENSE in the project root for more information.
namespace PhotoPrismalytics.PhotoPrism;

using Flurl;
using Flurl.Http;
using Serilog;

internal class PhotoPrismClientFactory : IPhotoPrismClientFactory
{
    private readonly ILogger _logger;

    public PhotoPrismClientFactory(ILogger logger)
    {
        _logger = logger;
    }

    internal IFlurlClient CreateFlurlClient(Url baseUrl)
    {
        var flurlClient = FlurlHttp.ConfigureClientForUrl(baseUrl)
                                   .WithSettings(settings =>
                                   {
                                       settings.Timeout = TimeSpan.FromSeconds(20);
                                   })
                                   .Build();

        flurlClient.OnError(call =>
        {
            _logger.Error(call.Exception,
                          "Requesting {Url} ({HttpMethod}) failed with status {Status}",
                          call.Request.Url,
                          call.Request.Verb.Method,
                          call.Response.StatusCode);
        });

        return flurlClient;
    }

    public IPhotoPrismClient CreatePhotoPrismClient(Url baseUrl, PhotoPrismAuthTokenProvider tokenProvider)
    {
        ArgumentNullException.ThrowIfNull(baseUrl);
        ArgumentNullException.ThrowIfNull(tokenProvider);

        _logger.Debug("Creating PhotoPrismClient for base URL {BaseUrl}", baseUrl);

        var flurlClient = CreateFlurlClient(baseUrl);
        var apiClient = new PhotoPrismApiClient(flurlClient, tokenProvider);
        return new PhotoPrismClient(apiClient);
    }
}
