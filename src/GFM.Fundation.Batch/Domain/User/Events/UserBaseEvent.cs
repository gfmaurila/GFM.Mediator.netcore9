using GFM.Fundation.App.Enuns;
using GFM.Fundation.Domain;

namespace GFM.Fundation.Batch.Domain.User.Events;

public abstract class UserBaseEvent : Event
{
    protected UserBaseEvent(Guid id, string firstName, string lastName, EGender gender)
    {
        Id = id;
        AggregateId = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
    }

    public Guid Id { get; private init; }
    public string FirstName { get; private init; }

    public string LastName { get; private init; }

    public EGender Gender { get; private init; }
}