using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Orden = table.Column<int>(type: "integer", nullable: false),
                    Creacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Orden = table.Column<int>(type: "integer", nullable: false),
                    Creacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MenuId = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MenuId = table.Column<int>(type: "integer", nullable: false),
                    RolId = table.Column<int>(type: "integer", nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuRol_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuRol_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Rut = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Anexo = table.Column<int>(type: "integer", nullable: true),
                    RolId = table.Column<int>(type: "integer", nullable: false),
                    LocacionId = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Locacion_LocacionId",
                        column: x => x.LocacionId,
                        principalTable: "Locacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locacion",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Direccion", "Nombre" },
                values: new object[] { 1, new DateTime(2022, 8, 9, 23, 6, 51, 7, DateTimeKind.Local).AddTicks(7957), false, "Direccion Servicio 1, Región Metropolitana", "Servicio 1" });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "Creacion", "CreatedDate", "Deleted", "Descripcion", "Icon", "Nombre", "Orden", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 9, 23, 6, 51, 7, DateTimeKind.Local).AddTicks(8285), new DateTime(2022, 8, 9, 23, 6, 51, 7, DateTimeKind.Local).AddTicks(8278), false, null, "mdi-home", "Inicio", 0, "/" },
                    { 2, new DateTime(2022, 8, 9, 23, 6, 51, 7, DateTimeKind.Local).AddTicks(8298), new DateTime(2022, 8, 9, 23, 6, 51, 7, DateTimeKind.Local).AddTicks(8295), false, null, "mdi-account-group-outline", "Usuarios", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Nombre" },
                values: new object[] { 1, new DateTime(2022, 8, 9, 23, 6, 51, 7, DateTimeKind.Local).AddTicks(8867), false, "Administrador" });

            migrationBuilder.InsertData(
                table: "MenuItem",
                columns: new[] { "Id", "Creacion", "CreatedDate", "Deleted", "Descripcion", "MenuId", "Nombre", "Orden", "Url" },
                values: new object[] { 1, new DateTime(2022, 8, 9, 23, 6, 51, 7, DateTimeKind.Local).AddTicks(8561), new DateTime(2022, 8, 9, 23, 6, 51, 7, DateTimeKind.Local).AddTicks(8555), false, null, 2, "Listar", 2, "/lista" });

            migrationBuilder.InsertData(
                table: "MenuRol",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Enabled", "MenuId", "RolId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 9, 23, 6, 51, 7, DateTimeKind.Local).AddTicks(8701), false, true, 1, 1 },
                    { 2, new DateTime(2022, 8, 9, 23, 6, 51, 7, DateTimeKind.Local).AddTicks(8707), false, true, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Anexo", "Apellido", "CreatedDate", "Deleted", "Email", "LocacionId", "Nombre", "Password", "RolId", "Rut", "Username" },
                values: new object[] { 1, null, "Taucare", new DateTime(2022, 8, 9, 23, 6, 51, 7, DateTimeKind.Local).AddTicks(9049), false, "ataucare@newtenberg.com", 1, "Alvaro", "YpJX//2e21/6kNyNBQj6dTgQ8/KIlcFrq1sC0CqVfCJ++CksgYLsTjlhVXwFwtq0yqg8X4Az+yissGtCYn4mt76gZCUuhpjtEGlF644zCZOvfrjfdmEnDKpbcYAxSxiMh5kE7rso7vdCLxJUXGHzGlD2v8/dNI+Zu8AZNoIVNf0=", 1, "15979991-3", "ataucare" });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuId",
                table: "MenuItem",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRol_MenuId",
                table: "MenuRol",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRol_RolId",
                table: "MenuRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_LocacionId",
                table: "Usuario",
                column: "LocacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "MenuRol");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Locacion");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
