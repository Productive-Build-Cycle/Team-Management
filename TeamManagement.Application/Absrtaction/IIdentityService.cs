using System;
using Application.Abstraction;

namespace Application.Abstraction

public interface IIdentityService
{
    Guid GetCurrentUserId();
}
