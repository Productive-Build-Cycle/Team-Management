using System;
using Application.Abstractions;

namespace Application.Abstractions;

public interface IIdentityService
{
    Guid GetCurrentUserId();
}
