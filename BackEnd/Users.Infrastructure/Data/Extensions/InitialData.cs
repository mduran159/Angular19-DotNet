using Users.Domain.Models;

namespace Users.Infrastructure.Data.Extensions;
internal class InitialData
{
    public static IEnumerable<User> Users =>
    new List<User>
    {
        User.Create(
            firstName: "John",
            lastName: "Doe",
            age: 30,
            gender: "Male",
            country: "USA",
            address: "123 Main St, New York",
            phone: "1234567890",
            email: "johndoe@example.com"
        ),
        User.Create(
            firstName: "Jane",
            lastName: "Smith",
            age: 25,
            gender: "Female",
            country: "Canada",
            address: "456 Elm St, Toronto",
            phone: "9876543210",
            email: "janesmith@example.com"
        ),
        User.Create(
            firstName: "Alice",
            lastName: "Brown",
            age: 35,
            gender: "Female",
            country: "UK",
            address: "789 Maple St, London",
            phone: "1122334455",
            email: "alicebrown@example.co.uk"
        ),
        User.Create(
            firstName: "Bob",
            lastName: "Johnson",
            age: 40,
            gender: "Male",
            country: "Australia",
            address: "159 Pine St, Sydney",
            phone: "6677889900",
            email: "bobjohnson@example.com.au"
        ),
        User.Create(
            firstName: "Emily",
            lastName: "Davis",
            age: 29,
            gender: "Female",
            country: "Germany",
            address: "357 Oak St, Berlin",
            phone: "5566778899",
            email: "emilydavis@example.de"
        ),
        User.Create(
            firstName: "Carlos",
            lastName: "Martinez",
            age: 32,
            gender: "Male",
            country: "Mexico",
            address: "12 Avenida Central, CDMX",
            phone: "5551234567",
            email: "carlos.martinez@example.mx"
        ),
        User.Create(
            firstName: "Sofia",
            lastName: "Gonzalez",
            age: 28,
            gender: "Female",
            country: "Spain",
            address: "Calle Mayor, Madrid",
            phone: "34678912345",
            email: "sofia.gonzalez@example.es"
        ),
        User.Create(
            firstName: "Liam",
            lastName: "Wilson",
            age: 27,
            gender: "Male",
            country: "Ireland",
            address: "89 Green St, Dublin",
            phone: "353871234567",
            email: "liamwilson@example.ie"
        ),
        User.Create(
            firstName: "Mia",
            lastName: "Taylor",
            age: 33,
            gender: "Female",
            country: "New Zealand",
            address: "22 Ocean View Rd, Wellington",
            phone: "6491234567",
            email: "mia.taylor@example.nz"
        ),
        User.Create(
            firstName: "Akira",
            lastName: "Tanaka",
            age: 31,
            gender: "Male",
            country: "Japan",
            address: "1-2-3 Ginza, Tokyo",
            phone: "81312345678",
            email: "akira.tanaka@example.jp"
        )
    };
}
