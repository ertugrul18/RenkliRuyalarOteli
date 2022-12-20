using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RenkliRuyalarOteli.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KullaniciId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KullaniciId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    MusteriTcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CepNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musteriler_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Odalar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdaNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KisiSayisi = table.Column<byte>(type: "tinyint", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odalar_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciRole",
                columns: table => new
                {
                    KullanicilarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RollerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRole", x => new { x.KullanicilarId, x.RollerId });
                    table.ForeignKey(
                        name: "FK_KullaniciRole_Kullanicilar_KullanicilarId",
                        column: x => x.KullanicilarId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciRole_Roller_RollerId",
                        column: x => x.RollerId,
                        principalTable: "Roller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdaFiyatlari",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Baslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fiyat = table.Column<float>(type: "real", nullable: false),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdaFiyatlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdaFiyatlari_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdaFiyatlari_Odalar_OdaId",
                        column: x => x.OdaId,
                        principalTable: "Odalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyonlar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdaFiyatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CikisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusteriId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyonlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_OdaFiyatlari_OdaFiyatId",
                        column: x => x.OdaFiyatId,
                        principalTable: "OdaFiyatlari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Odalar_OdaId",
                        column: x => x.OdaId,
                        principalTable: "Odalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RezervasyonDetaylari",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RezervasyonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusteriId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervasyonDetaylari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RezervasyonDetaylari_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RezervasyonDetaylari_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervasyonDetaylari_Rezervasyonlar_RezervasyonId",
                        column: x => x.RezervasyonId,
                        principalTable: "Rezervasyonlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_Email",
                table: "Kullanicilar",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_KullaniciAdi",
                table: "Kullanicilar",
                column: "KullaniciAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_TcNo",
                table: "Kullanicilar",
                column: "TcNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRole_RollerId",
                table: "KullaniciRole",
                column: "RollerId");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_KullaniciId",
                table: "Musteriler",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_OdaFiyatlari_KullaniciId",
                table: "OdaFiyatlari",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_OdaFiyatlari_OdaId",
                table: "OdaFiyatlari",
                column: "OdaId");

            migrationBuilder.CreateIndex(
                name: "IX_Odalar_KullaniciId",
                table: "Odalar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervasyonDetaylari_KullaniciId",
                table: "RezervasyonDetaylari",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervasyonDetaylari_MusteriId",
                table: "RezervasyonDetaylari",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervasyonDetaylari_RezervasyonId",
                table: "RezervasyonDetaylari",
                column: "RezervasyonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_KullaniciId",
                table: "Rezervasyonlar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_MusteriId",
                table: "Rezervasyonlar",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_OdaFiyatId",
                table: "Rezervasyonlar",
                column: "OdaFiyatId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_OdaId",
                table: "Rezervasyonlar",
                column: "OdaId");

            migrationBuilder.CreateIndex(
                name: "IX_Roller_RoleName",
                table: "Roller",
                column: "RoleName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KullaniciRole");

            migrationBuilder.DropTable(
                name: "RezervasyonDetaylari");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Rezervasyonlar");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "OdaFiyatlari");

            migrationBuilder.DropTable(
                name: "Odalar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
