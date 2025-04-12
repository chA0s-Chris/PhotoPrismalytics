// Copyright (c) 2025 Christian Flessa. All rights reserved.
// This file is licensed under the MIT license. See LICENSE in the project root for more information.
namespace PhotoPrismalytics.PhotoPrism;

public abstract class PhotoPrismAuthTokenProvider
{
    public abstract Task<String> GetAuthTokenAsync(CancellationToken cancellationToken = default);
}
