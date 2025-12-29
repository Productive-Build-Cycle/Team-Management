using system;
using Application.Abstraction.CQRS;


namespace Application.Abstraction.CQRS;

public sealed record AddMember(
    Guid TeamId,
    Guid MemberId,
    ) : ICommand;

public class Class1
{
	public Class1()
	{
	}
}
