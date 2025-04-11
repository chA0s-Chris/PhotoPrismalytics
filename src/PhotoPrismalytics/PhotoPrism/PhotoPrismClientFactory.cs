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

    public IPhotoPrismClient CreatePhotoPrismClient(Url baseUrl)
    {
        ArgumentNullException.ThrowIfNull(baseUrl);

        _logger.Debug("Creating PhotoPrismClient for base URL {BaseUrl}", baseUrl);

        var flurlClient = new FlurlClient(baseUrl);
        var apiClient = new PhotoPrismApiClient(flurlClient);
        return new PhotoPrismClient(apiClient);
    }
}
