using GFM.Fundation.App.Enuns;
using GFM.Fundation.Batch.Domain.User.Events;
using GFM.Fundation.Domain;

namespace GFM.Fundation.Batch.Domain.User;

public class UserEntity : BaseEntity, IAggregateRoot
{
    public UserEntity() { } // ORM

    /// <summary>
    /// Primeiro Nome.
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Sobrenome.
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Gênero.
    /// </summary>
    public EGender Gender { get; private set; }

    public UserEntity(string firstName, string lastName, EGender gender)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;

        Id = Guid.NewGuid();

        Console.WriteLine($"UserEntity > {DateTime.Now}");
        // Adicionando a nova instãncia nos eventos de domínio.
        AddDomainEvent(new UserCreatedEvent(Id, firstName, lastName, gender));
    }
}
