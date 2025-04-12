// Copyright (c) 2025 Christian Flessa. All rights reserved.
// This file is licensed under the MIT license. See LICENSE in the project root for more information.
namespace PhotoPrismalytics.PhotoPrism;

public class PhotoPrismBearerTokenProvider : PhotoPrismAuthTokenProvider
{
    private readonly String _bearerToken;

    public PhotoPrismBearerTokenProvider(String bearerToken)
    {
        _bearerToken = bearerToken;
    }

    public override Task<String> GetAuthTokenAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(_bearerToken);
}
