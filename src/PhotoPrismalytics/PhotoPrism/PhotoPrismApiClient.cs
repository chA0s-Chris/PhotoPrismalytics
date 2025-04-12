// Copyright (c) 2025 Christian Flessa. All rights reserved.
// This file is licensed under the MIT license. See LICENSE in the project root for more information.
namespace PhotoPrismalytics.PhotoPrism;

using Flurl.Http;

internal class PhotoPrismApiClient : IPhotoPrismApiClient
{
    private readonly IFlurlClient _flurlClient;
    private readonly PhotoPrismAuthTokenProvider _tokenProvider;

    public PhotoPrismApiClient(IFlurlClient flurlClient, PhotoPrismAuthTokenProvider tokenProvider)
    {
        _flurlClient = flurlClient;
        _tokenProvider = tokenProvider;

        _flurlClient.BeforeCall(AddAuthTokenHeader);
    }

    internal async Task AddAuthTokenHeader(FlurlCall call)
    {
        var token = await _tokenProvider.GetAuthTokenAsync();
        call.Request.WithOAuthBearerToken(token);
    }
}
