using System.ComponentModel.DataAnnotations;
using Users.Domain.Abstractions;

namespace Users.Domain.Models;
public class User : Entity<Guid>
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public int Age { get; private set; } = 0;
    public string Gender { get; private set; } = string.Empty;
    public string Country { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    private User() { } // Private constructor to force the usage of the Create method

    public static User Create(
        string firstName,
        string lastName,
        int age,
        string gender,
        string country,
        string address,
        string phone,
        string email)
    {
        // Validations
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName, nameof(firstName));
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName, nameof(lastName));
        if (age < 0 || age > 99) throw new ArgumentOutOfRangeException(nameof(age), "Age must be between 0 and 99.");
        ArgumentException.ThrowIfNullOrWhiteSpace(gender, nameof(gender));
        ArgumentException.ThrowIfNullOrWhiteSpace(country, nameof(country));
        ArgumentException.ThrowIfNullOrWhiteSpace(address, nameof(address));
        ArgumentException.ThrowIfNullOrWhiteSpace(phone, nameof(phone));
        ArgumentException.ThrowIfNullOrWhiteSpace(email, nameof(email));

        if (!email.Contains("@") || !System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$"))
        {
            throw new ArgumentException("Invalid email format. Email must contain '@' and a valid domain extension.", nameof(email));
        }

        // Create User
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Age = age,
            Gender = gender,
            Country = country,
            Address = address,
            Phone = phone,
            Email = email
        };

        return user;
    }

    public void Update(
    string firstName,
    string lastName,
    int age,
    string gender,
    string country,
    string address,
    string phone,
    string email)
    {
        // Validaciones
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName, nameof(firstName));
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName, nameof(lastName));
        if (age < 0 || age > 99) throw new ArgumentOutOfRangeException(nameof(age), "Age must be between 0 and 99.");
        ArgumentException.ThrowIfNullOrWhiteSpace(gender, nameof(gender));
        ArgumentException.ThrowIfNullOrWhiteSpace(country, nameof(country));
        ArgumentException.ThrowIfNullOrWhiteSpace(address, nameof(address));
        ArgumentException.ThrowIfNullOrWhiteSpace(phone, nameof(phone));
        ArgumentException.ThrowIfNullOrWhiteSpace(email, nameof(email));

        if (!email.Contains("@") || !System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$"))
        {
            throw new ArgumentException("Invalid email format. Email must contain '@' and a valid domain extension.", nameof(email));
        }

        // Actualizar las propiedades
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Gender = gender;
        Country = country;
        Address = address;
        Phone = phone;
        Email = email;
    }
}