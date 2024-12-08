using AxionApi.Domain.Primitives;

namespace AxionApi.Domain.Models;

public sealed class User : AggregateRoot
{
    private User(
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Address,
        string PasswordHash)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.PhoneNumber = PhoneNumber;
        this.Address = Address;
        this.PasswordHash = PasswordHash;
    }


    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Address { get; private set; }
    public string PasswordHash { get; private set; }


    public static User Create(string FirstName,
        string LastName,
        string PhoneNumber,
        string Address,
        string PasswordHash)
    {
        var response = new User(FirstName, LastName, PhoneNumber, Address, PasswordHash);
        return response;

    }
}
