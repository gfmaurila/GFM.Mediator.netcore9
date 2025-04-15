using GFM.Fundation.App.Enuns;

namespace GFM.Fundation.Batch.Domain.User.Events;

public class UserCreatedEvent : UserBaseEvent
{
    public UserCreatedEvent(Guid id, string firstName, string lastName, EGender gender) :
        base(id, firstName, lastName, gender)
    {
    }
}
