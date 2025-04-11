// Copyright (c) 2025 Christian Flessa. All rights reserved.
// This file is licensed under the MIT license. See LICENSE in the project root for more information.
namespace PhotoPrismalytics.PhotoPrism;

using Flurl.Http;

internal class PhotoPrismApiClient : IPhotoPrismApiClient
{
    private readonly IFlurlClient _flurlClient;

    public PhotoPrismApiClient(IFlurlClient flurlClient)
    {
        _flurlClient = flurlClient;
    }
}
