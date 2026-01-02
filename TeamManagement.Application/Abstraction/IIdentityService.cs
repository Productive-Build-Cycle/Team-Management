namespace TeamManagement.Application.Abstraction;

public interface IIdentityService
{
    Guid GetCurrentUserId();
}
