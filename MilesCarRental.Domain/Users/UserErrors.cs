using MilesCarRental.Domain.Abstractions;

namespace MilesCarRental.Domain.Users;

public static class UserErrors
{
    public static Error NotFound = new("User.NotFound", "No existe el usuario buscado por este id");
    public static Error InvalidCredentials = new("User.InvalidCredentials", "Las credenciales son incorrectas");
}
