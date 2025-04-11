// Copyright (c) 2025 Christian Flessa. All rights reserved.
// This file is licensed under the MIT license. See LICENSE in the project root for more information.
namespace PhotoPrismalytics.PhotoPrism;

internal class PhotoPrismClient : IPhotoPrismClient
{
    private readonly IPhotoPrismApiClient _apiClient;

    public PhotoPrismClient(IPhotoPrismApiClient apiClient)
    {
        _apiClient = apiClient;
    }
}
