using Dapper;
using MilesCarRental.Application.Abstractions.Data;
using MilesCarRental.Application.Abstractions.Messaging;
using MilesCarRental.Application.Exceptions;
using MilesCarRental.Domain.Abstractions;
using MilesCarRental.Domain.Vehiculos;
using System.Data;

namespace MilesCarRental.Application.Vehiculos.GetVehiculosDisponibles;

internal sealed class GetVehiculosDisponiblesQueryHandler : IQueryHandler<GetVehiculosDisponiblesQuery, IReadOnlyList<VehiculoDisponibleResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetVehiculosDisponiblesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<VehiculoDisponibleResponse>>> Handle(GetVehiculosDisponiblesQuery request, CancellationToken cancellationToken)
    {
        if (request.LocalidadRecogidaId == Guid.Empty)
        {
            return Result.Failure<IReadOnlyList<VehiculoDisponibleResponse>>(VehiculoErrors.LocalidadRecogida);
        }

        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
        SELECT 
            v.id AS VehiculoId,
            v.modelo AS Modelo,
            v.vin AS Vin,
            v.precio_monto AS PrecioMonto,
            v.precio_tipo_moneda AS PrecioTipoMoneda,
            v.mantenimiento_monto AS MantenimientoMonto,
            v.mantenimiento_tipo_moneda AS MantenimientoTipoMoneda,
            lr.nombre AS LocalidadRecogida,
            ld.nombre AS LocalidadDevolucion,
            m.nombre AS Mercado,
            dv.fecha_inicio AS FechaInicio,
            dv.fecha_fin AS FechaFin,
            dv.disponible AS Disponible
        FROM disponibilidad_vehiculo dv
        INNER JOIN vehiculos v ON dv.vehiculo_id = v.id
        INNER JOIN localidades lr ON dv.localidad_recogida_id = lr.id
        INNER JOIN localidades ld ON dv.localidad_devolucion_id = ld.id
        INNER JOIN localidad_mercado lm ON lm.localidad_id = lr.id
        INNER JOIN mercados m ON m.id = lm.mercado_id
        INNER JOIN vehiculo_mercado vm ON vm.vehiculo_id = v.id AND vm.mercado_id = m.id
        WHERE dv.localidad_recogida_id = @LocalidadRecogidaId
          AND (@LocalidadDevolucionId IS NULL OR dv.localidad_devolucion_id = @LocalidadDevolucionId)
          AND (@MercadoId IS NULL OR m.id = @MercadoId)
          AND (@FechaInicio IS NULL OR dv.fecha_inicio <= @FechaInicio)
          AND (@FechaFin IS NULL OR dv.fecha_fin >= @FechaFin)
          AND CURRENT_DATE BETWEEN dv.fecha_inicio::date AND dv.fecha_fin::date
          AND dv.disponible = TRUE
        ORDER BY v.modelo;
        """;

        var parameters = new DynamicParameters();
        parameters.Add("LocalidadRecogidaId", request.LocalidadRecogidaId, DbType.Guid);
        parameters.Add("LocalidadDevolucionId", request.LocalidadDevolucionId, DbType.Guid);
        parameters.Add("MercadoId", request.MercadoId, DbType.Guid);
        parameters.Add("FechaInicio", request.FechaInicio, DbType.DateTime);
        parameters.Add("FechaFin", request.FechaFin, DbType.DateTime);

        var vehiculos = await connection.QueryAsync<VehiculoDisponibleResponse>(
            sql,
            parameters
        );

        return vehiculos.ToList();
    }
}