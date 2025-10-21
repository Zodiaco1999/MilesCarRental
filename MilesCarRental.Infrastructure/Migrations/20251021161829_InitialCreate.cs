using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilesCarRental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "localidades",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    pais = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    departamento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    provincia = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ciudad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    calle = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_localidades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mercados",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mercados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    apellido = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    email = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehiculos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    modelo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    vin = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    localidad_id = table.Column<Guid>(type: "uuid", nullable: false),
                    precio_monto = table.Column<decimal>(type: "numeric", nullable: false),
                    precio_tipo_moneda = table.Column<string>(type: "text", nullable: false),
                    mantenimiento_monto = table.Column<decimal>(type: "numeric", nullable: false),
                    mantenimiento_tipo_moneda = table.Column<string>(type: "text", nullable: false),
                    fecha_ultima_alquiler = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    accesorios = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehiculos", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehiculos_localidades_localidad_id",
                        column: x => x.localidad_id,
                        principalTable: "localidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "localidad_mercado",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    localidad_id = table.Column<Guid>(type: "uuid", nullable: false),
                    mercado_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_localidad_mercado", x => x.id);
                    table.ForeignKey(
                        name: "fk_localidad_mercado_localidades_localidad_id",
                        column: x => x.localidad_id,
                        principalTable: "localidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_localidad_mercado_mercado_mercado_id",
                        column: x => x.mercado_id,
                        principalTable: "mercados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "alquileres",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehiculo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    precio_por_periodo_monto = table.Column<decimal>(type: "numeric", nullable: true),
                    precio_por_periodo_tipo_moneda = table.Column<string>(type: "text", nullable: true),
                    mantenimiento_monto = table.Column<decimal>(type: "numeric", nullable: true),
                    mantenimiento_tipo_moneda = table.Column<string>(type: "text", nullable: true),
                    accesorios_monto = table.Column<decimal>(type: "numeric", nullable: true),
                    accesorios_tipo_moneda = table.Column<string>(type: "text", nullable: true),
                    precio_total_monto = table.Column<decimal>(type: "numeric", nullable: true),
                    precio_total_tipo_moneda = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    duracion_inicio = table.Column<DateOnly>(type: "date", nullable: true),
                    duracion_fin = table.Column<DateOnly>(type: "date", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_confirmacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_denegacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_completado = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_cancelacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_alquileres", x => x.id);
                    table.ForeignKey(
                        name: "fk_alquileres_user_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_alquileres_vehiculo_vehiculo_id",
                        column: x => x.vehiculo_id,
                        principalTable: "vehiculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "disponibilidad_vehiculo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehiculo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    localidad_recogida_id = table.Column<Guid>(type: "uuid", nullable: false),
                    localidad_devolucion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    disponible = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_disponibilidad_vehiculo", x => x.id);
                    table.ForeignKey(
                        name: "FK_DisponibilidadVehiculo_LocalidadDevolucion",
                        column: x => x.localidad_devolucion_id,
                        principalTable: "localidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisponibilidadVehiculo_LocalidadRecogida",
                        column: x => x.localidad_recogida_id,
                        principalTable: "localidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_disponibilidad_vehiculo_vehiculo_vehiculo_id",
                        column: x => x.vehiculo_id,
                        principalTable: "vehiculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vehiculo_mercado",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehiculo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    mercado_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehiculo_mercado", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehiculo_mercado_mercados_mercado_id",
                        column: x => x.mercado_id,
                        principalTable: "mercados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_vehiculo_mercado_vehiculos_vehiculo_id",
                        column: x => x.vehiculo_id,
                        principalTable: "vehiculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehiculo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    alquiler_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    comentario = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reviews", x => x.id);
                    table.ForeignKey(
                        name: "fk_reviews_alquileres_alquiler_id",
                        column: x => x.alquiler_id,
                        principalTable: "alquileres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reviews_user_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reviews_vehiculo_vehiculo_id",
                        column: x => x.vehiculo_id,
                        principalTable: "vehiculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_alquileres_user_id",
                table: "alquileres",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_alquileres_vehiculo_id",
                table: "alquileres",
                column: "vehiculo_id");

            migrationBuilder.CreateIndex(
                name: "ix_disponibilidad_vehiculo_localidad_devolucion_id",
                table: "disponibilidad_vehiculo",
                column: "localidad_devolucion_id");

            migrationBuilder.CreateIndex(
                name: "ix_disponibilidad_vehiculo_localidad_recogida_id",
                table: "disponibilidad_vehiculo",
                column: "localidad_recogida_id");

            migrationBuilder.CreateIndex(
                name: "ix_disponibilidad_vehiculo_vehiculo_id",
                table: "disponibilidad_vehiculo",
                column: "vehiculo_id");

            migrationBuilder.CreateIndex(
                name: "ix_localidad_mercado_localidad_id",
                table: "localidad_mercado",
                column: "localidad_id");

            migrationBuilder.CreateIndex(
                name: "ix_localidad_mercado_mercado_id",
                table: "localidad_mercado",
                column: "mercado_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_alquiler_id",
                table: "reviews",
                column: "alquiler_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_user_id",
                table: "reviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_vehiculo_id",
                table: "reviews",
                column: "vehiculo_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehiculo_mercado_mercado_id",
                table: "vehiculo_mercado",
                column: "mercado_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehiculo_mercado_vehiculo_id",
                table: "vehiculo_mercado",
                column: "vehiculo_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehiculos_localidad_id",
                table: "vehiculos",
                column: "localidad_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "disponibilidad_vehiculo");

            migrationBuilder.DropTable(
                name: "localidad_mercado");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "vehiculo_mercado");

            migrationBuilder.DropTable(
                name: "alquileres");

            migrationBuilder.DropTable(
                name: "mercados");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "vehiculos");

            migrationBuilder.DropTable(
                name: "localidades");
        }
    }
}
