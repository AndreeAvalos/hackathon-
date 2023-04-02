using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiRest.Migrations
{
    public partial class Catalogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "derivative_catalog",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_derivative_catalog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "energy_catalog",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_energy_catalog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "energy_type_catalog",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_energy_type_catalog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fuel_catalog",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fuel_catalog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "issuance_catalog",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issuance_catalog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "petroleum_catalog",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_petroleum_catalog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "travel_catalog",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_travel_catalog", x => x.id);
                },
                comment: "Kind of travel");

            migrationBuilder.CreateTable(
                name: "energy_consumption",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    units = table.Column<double>(type: "double precision", nullable: false, comment: "Number of unit per use"),
                    consumption_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    energy_catalog_id = table.Column<int>(type: "integer", nullable: false),
                    issuance_catalog_id = table.Column<int>(type: "integer", nullable: false),
                    energy_type_catalog_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_energy_consumption", x => x.id);
                    table.ForeignKey(
                        name: "FK_energy_consumption_energy_catalog_energy_catalog_id",
                        column: x => x.energy_catalog_id,
                        principalTable: "energy_catalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_energy_consumption_energy_type_catalog_energy_type_catalog_~",
                        column: x => x.energy_type_catalog_id,
                        principalTable: "energy_type_catalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_energy_consumption_issuance_catalog_issuance_catalog_id",
                        column: x => x.issuance_catalog_id,
                        principalTable: "issuance_catalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fuel_consumption",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    units = table.Column<double>(type: "double precision", nullable: false, comment: "Number of unit per use"),
                    consumption_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fuel_catalog_id = table.Column<int>(type: "integer", nullable: false),
                    issuance_catalog_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fuel_consumption", x => x.id);
                    table.ForeignKey(
                        name: "FK_fuel_consumption_fuel_catalog_fuel_catalog_id",
                        column: x => x.fuel_catalog_id,
                        principalTable: "fuel_catalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fuel_consumption_issuance_catalog_issuance_catalog_id",
                        column: x => x.issuance_catalog_id,
                        principalTable: "issuance_catalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "petroleum_consumption",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    units = table.Column<double>(type: "double precision", nullable: false, comment: "Number of unit per use"),
                    consumption_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    petroleum_catalog_id = table.Column<int>(type: "integer", nullable: false),
                    issuance_catalog_id = table.Column<int>(type: "integer", nullable: false),
                    derivative_catalog_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_petroleum_consumption", x => x.id);
                    table.ForeignKey(
                        name: "FK_petroleum_consumption_derivative_catalog_derivative_catalog~",
                        column: x => x.derivative_catalog_id,
                        principalTable: "derivative_catalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_petroleum_consumption_issuance_catalog_issuance_catalog_id",
                        column: x => x.issuance_catalog_id,
                        principalTable: "issuance_catalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_petroleum_consumption_petroleum_catalog_petroleum_catalog_id",
                        column: x => x.petroleum_catalog_id,
                        principalTable: "petroleum_catalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "travel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    destination = table.Column<string>(type: "text", nullable: false),
                    travel_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    issuance_catalog_id = table.Column<int>(type: "integer", nullable: false),
                    travel_catalog_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_travel", x => x.id);
                    table.ForeignKey(
                        name: "FK_travel_issuance_catalog_issuance_catalog_id",
                        column: x => x.issuance_catalog_id,
                        principalTable: "issuance_catalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_travel_travel_catalog_travel_catalog_id",
                        column: x => x.travel_catalog_id,
                        principalTable: "travel_catalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Number of travels");

            migrationBuilder.InsertData(
                table: "derivative_catalog",
                columns: new[] { "id", "active", "deleted_at", "description", "name", "updated_at" },
                values: new object[,]
                {
                    { -4, true, null, "Unidad para metros", "metro", null },
                    { -3, true, null, "Unidad para litros", "litro", null },
                    { -2, true, null, "Unidad para galones", "galon", null },
                    { -1, true, null, "Unidad para hojas", "hoja", null }
                });

            migrationBuilder.InsertData(
                table: "energy_catalog",
                columns: new[] { "id", "active", "deleted_at", "description", "name", "updated_at" },
                values: new object[,]
                {
                    { -3, true, null, "Consumo de distribucion", "distribucion", null },
                    { -2, true, null, "Consumo logistico", "logistico", null },
                    { -1, true, null, "Consumo administrativo", "administrativo", null }
                });

            migrationBuilder.InsertData(
                table: "energy_type_catalog",
                columns: new[] { "id", "active", "deleted_at", "description", "name", "updated_at" },
                values: new object[,]
                {
                    { -3, true, null, "Energia consumida por otros", "etc", null },
                    { -2, true, null, "Energia consumida por oficicnas administrativas", "oficinas administrativas", null },
                    { -1, true, null, "Energia consumida por la envasadora", "envasado", null }
                });

            migrationBuilder.InsertData(
                table: "fuel_catalog",
                columns: new[] { "id", "active", "deleted_at", "description", "name", "updated_at" },
                values: new object[,]
                {
                    { -3, true, null, "Combustible de logistica", "distribucion", null },
                    { -2, true, null, "Combustible indirecto de proveedor", "indirect", null },
                    { -1, true, null, "Combustible administrativo", "administrativo", null }
                });

            migrationBuilder.InsertData(
                table: "issuance_catalog",
                columns: new[] { "id", "active", "deleted_at", "description", "name", "updated_at" },
                values: new object[,]
                {
                    { -3, true, null, "Asociadas a otras actividades no controladas por la organización", "otras", null },
                    { -2, true, null, "Asociadas al consumo energético adquirido y consumido por la organización.", "indirectas", null },
                    { -1, true, null, "Ssociadas a las actividades de la organización y que están controladas por dicha organización", "directas", null }
                });

            migrationBuilder.InsertData(
                table: "petroleum_catalog",
                columns: new[] { "id", "active", "deleted_at", "description", "name", "updated_at" },
                values: new object[,]
                {
                    { -3, true, null, "Consumo de operacion", "distribucion", null },
                    { -2, true, null, "Consumo logistico", "logistico", null },
                    { -1, true, null, "Consumo administrativo", "administrativo", null }
                });

            migrationBuilder.InsertData(
                table: "travel_catalog",
                columns: new[] { "id", "active", "deleted_at", "description", "name", "updated_at" },
                values: new object[,]
                {
                    { -3, true, null, "Equipo de tecnologia", "IT", null },
                    { -2, true, null, "Equipo de ventas", "Ventas", null },
                    { -1, true, null, "CEO y COO", "Alto Mando", null }
                });

            migrationBuilder.InsertData(
                table: "energy_consumption",
                columns: new[] { "id", "active", "consumption_date", "deleted_at", "energy_catalog_id", "energy_type_catalog_id", "issuance_catalog_id", "units", "updated_at" },
                values: new object[,]
                {
                    { -15, true, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -3, -2, -3, 777.0, null },
                    { -14, true, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -3, -2, 777.0, null },
                    { -13, true, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -2, -1, 777.0, null },
                    { -12, true, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -1, -3, 777.0, null },
                    { -11, true, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -3, -2, -1, 777.0, null },
                    { -10, true, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -3, -2, 777.0, null },
                    { -9, true, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -3, -3, 777.0, null },
                    { -8, true, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -3, -2, 777.0, null },
                    { -7, true, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -1, -2, 777.0, null },
                    { -6, true, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -2, -2, 900.0, null },
                    { -5, true, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -2, -2, 900.0, null },
                    { -4, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -2, -2, 900.0, null },
                    { -3, true, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -1, -1, 300.0, null },
                    { -2, true, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -1, -1, 300.0, null },
                    { -1, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -1, -1, 300.0, null }
                });

            migrationBuilder.InsertData(
                table: "fuel_consumption",
                columns: new[] { "id", "active", "consumption_date", "deleted_at", "fuel_catalog_id", "issuance_catalog_id", "units", "updated_at" },
                values: new object[,]
                {
                    { -28, true, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -3, 444.0, null },
                    { -27, true, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -3, -3, 22.0, null },
                    { -26, true, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, 623.0, null },
                    { -25, true, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -2, 664.0, null },
                    { -24, true, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -3, -2, 6665.0, null },
                    { -23, true, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -3, -3, 6699.0, null },
                    { -22, true, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, 68.0, null },
                    { -21, true, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -2, 667.0, null },
                    { -20, true, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -3, 666.0, null },
                    { -19, true, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -2, 250.0, null },
                    { -18, true, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -2, 250.0, null },
                    { -17, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -2, 250.0, null },
                    { -16, true, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -2, 250.0, null },
                    { -15, true, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -2, 250.0, null },
                    { -14, true, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -2, 250.0, null },
                    { -13, true, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -2, 250.0, null },
                    { -12, true, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -3, 250.0, null },
                    { -11, true, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -3, 1000.0, null },
                    { -10, true, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -3, 250.0, null },
                    { -9, true, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -3, 1000.0, null },
                    { -8, true, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -3, 250.0, null },
                    { -7, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -3, 1000.0, null },
                    { -6, true, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, 250.0, null },
                    { -5, true, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, 500.0, null },
                    { -4, true, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, 250.0, null },
                    { -3, true, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, 500.0, null },
                    { -2, true, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, 250.0, null },
                    { -1, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, 500.0, null }
                });

            migrationBuilder.InsertData(
                table: "petroleum_consumption",
                columns: new[] { "id", "active", "consumption_date", "deleted_at", "derivative_catalog_id", "issuance_catalog_id", "petroleum_catalog_id", "units", "updated_at" },
                values: new object[,]
                {
                    { -40, true, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -3, -3, -1, 42.0, null },
                    { -39, true, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -3, -3, 42.0, null },
                    { -38, true, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -3, -2, 42.0, null },
                    { -37, true, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -3, -2, -1, 42.0, null },
                    { -36, true, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -2, -3, 42.0, null },
                    { -35, true, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -2, -1, 42.0, null },
                    { -34, true, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -3, -1, -2, 42.0, null },
                    { -33, true, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -1, -3, 42.0, null },
                    { -32, true, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -2, 42.0, null },
                    { -31, true, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -3, -1, 22.0, null },
                    { -30, true, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -3, -1, 22.0, null },
                    { -29, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -3, -1, 22.0, null },
                    { -28, true, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -3, -1, 3.0, null },
                    { -27, true, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -3, -1, 3.0, null },
                    { -26, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -2, -3, -1, 3.0, null },
                    { -25, true, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 6600.0, null },
                    { -24, true, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 6600.0, null },
                    { -23, true, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 6600.0, null },
                    { -22, true, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -21, true, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -20, true, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -19, true, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -18, true, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -17, true, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -16, true, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -15, true, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -14, true, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -13, true, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -12, true, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -11, true, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -10, true, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -9, true, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -8, true, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -7, true, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -6, true, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -5, true, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -4, true, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -3, true, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -2, true, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null },
                    { -1, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null, -1, -1, -1, 300.0, null }
                });

            migrationBuilder.InsertData(
                table: "travel",
                columns: new[] { "id", "active", "deleted_at", "destination", "issuance_catalog_id", "travel_catalog_id", "travel_date", "updated_at" },
                values: new object[,]
                {
                    { -18, true, null, "Guatemala", -1, -3, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -17, true, null, "Panama", -1, -2, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -16, true, null, "El Salvador", -1, -1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -15, true, null, "Guatemala", -1, -1, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -14, true, null, "Panama", -1, -1, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -13, true, null, "El Salvador", -1, -1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -12, true, null, "Guatemala", -1, -2, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -11, true, null, "Panama", -1, -2, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -10, true, null, "El Salvador", -1, -3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -9, true, null, "Guatemala", -1, -2, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -8, true, null, "Panama", -1, -1, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -7, true, null, "El Salvador", -1, -1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -6, true, null, "Guatemala", -1, -2, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -5, true, null, "Panama", -1, -2, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -4, true, null, "El Salvador", -1, -2, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -3, true, null, "Guatemala", -1, -1, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -2, true, null, "Panama", -1, -1, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null },
                    { -1, true, null, "El Salvador", -1, -1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).ToUniversalTime(), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_energy_consumption_energy_catalog_id",
                table: "energy_consumption",
                column: "energy_catalog_id");

            migrationBuilder.CreateIndex(
                name: "IX_energy_consumption_energy_type_catalog_id",
                table: "energy_consumption",
                column: "energy_type_catalog_id");

            migrationBuilder.CreateIndex(
                name: "IX_energy_consumption_issuance_catalog_id",
                table: "energy_consumption",
                column: "issuance_catalog_id");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_consumption_fuel_catalog_id",
                table: "fuel_consumption",
                column: "fuel_catalog_id");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_consumption_issuance_catalog_id",
                table: "fuel_consumption",
                column: "issuance_catalog_id");

            migrationBuilder.CreateIndex(
                name: "IX_petroleum_consumption_derivative_catalog_id",
                table: "petroleum_consumption",
                column: "derivative_catalog_id");

            migrationBuilder.CreateIndex(
                name: "IX_petroleum_consumption_issuance_catalog_id",
                table: "petroleum_consumption",
                column: "issuance_catalog_id");

            migrationBuilder.CreateIndex(
                name: "IX_petroleum_consumption_petroleum_catalog_id",
                table: "petroleum_consumption",
                column: "petroleum_catalog_id");

            migrationBuilder.CreateIndex(
                name: "IX_travel_issuance_catalog_id",
                table: "travel",
                column: "issuance_catalog_id");

            migrationBuilder.CreateIndex(
                name: "IX_travel_travel_catalog_id",
                table: "travel",
                column: "travel_catalog_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "energy_consumption");

            migrationBuilder.DropTable(
                name: "fuel_consumption");

            migrationBuilder.DropTable(
                name: "petroleum_consumption");

            migrationBuilder.DropTable(
                name: "travel");

            migrationBuilder.DropTable(
                name: "energy_catalog");

            migrationBuilder.DropTable(
                name: "energy_type_catalog");

            migrationBuilder.DropTable(
                name: "fuel_catalog");

            migrationBuilder.DropTable(
                name: "derivative_catalog");

            migrationBuilder.DropTable(
                name: "petroleum_catalog");

            migrationBuilder.DropTable(
                name: "issuance_catalog");

            migrationBuilder.DropTable(
                name: "travel_catalog");
        }
    }
}
