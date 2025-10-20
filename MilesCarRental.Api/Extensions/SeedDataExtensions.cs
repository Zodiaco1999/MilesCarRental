using Bogus;
using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Domain.Vehiculos;
using Dapper;

namespace CleanArquitecture.Api.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using var connection = sqlConnectionFactory.CreateConnection();

        var faker = new Faker();
        List<object> vehiculos = new();

        for (int i = 0; i < 100; i++)
        {
            var vehiculo = new
            {
                Id = Guid.NewGuid(),
                Vin = faker.Vehicle.Vin(),
                Modelo = faker.Vehicle.Model(),
                Pais = faker.Address.Country(),
                Departamento = faker.Address.State(),
                Provincia = faker.Address.County(),
                Ciudad = faker.Address.City(),
                Calle = faker.Address.StreetAddress(),
                PrecioMonto = faker.Random.Decimal(1000, 20000),
                PrecioTipoMoneda = "USD",
                PrecioMantenimiento = faker.Random.Decimal(100, 200),
                PrecioMantenimientoTipoMoneda = "USD",
                Accessorios = new List<int> { (int)Accesorio.Wifi, (int)Accesorio.AppleCar },
                FechaUltima = DateTime.MinValue
            };
            vehiculos.Add(vehiculo);
        }

        var sqlInsert = """
            INSERT INTO public.vehiculos
            (id, modelo, vin, direccion_pais, direccion_departamento, direccion_provincia, direccion_ciudad, direccion_calle, precio_monto, precio_tipo_moneda, mantenimiento_monto, mantenimiento_tipo_moneda, fecha_ultima_alquiler, accesorios)
            VALUES(@Id, @Modelo, @Vin, @Pais, @Departamento, @Provincia, @Ciudad, @Calle, @PrecioMonto, @PrecioTipoMoneda, @PrecioMantenimiento, @PrecioMantenimientoTipoMoneda, @FechaUltima, @Accessorios);
            """;

        connection.Execute(sqlInsert, vehiculos);
    }

}
