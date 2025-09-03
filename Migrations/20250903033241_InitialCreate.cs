using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace pojokkamera_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori_Produk",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaKategori = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori_Produk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merek",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaMerek = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipe_Mount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaMount = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipe_Mount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HashKataSandi = table.Column<string>(type: "text", nullable: false),
                    NamaLengkap = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NomorTelepon = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DibuatPada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kamera",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMerek = table.Column<long>(type: "bigint", nullable: false),
                    IdKategori = table.Column<long>(type: "bigint", nullable: false),
                    IdMount = table.Column<long>(type: "bigint", nullable: true),
                    Nama = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Sku = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    Harga = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    JumlahStok = table.Column<int>(type: "integer", nullable: false),
                    UrlGambar = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kamera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kamera_Kategori_Produk_IdKategori",
                        column: x => x.IdKategori,
                        principalTable: "Kategori_Produk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kamera_Merek_IdMerek",
                        column: x => x.IdMerek,
                        principalTable: "Merek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kamera_Tipe_Mount_IdMount",
                        column: x => x.IdMount,
                        principalTable: "Tipe_Mount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lensa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMerek = table.Column<long>(type: "bigint", nullable: false),
                    IdKategori = table.Column<long>(type: "bigint", nullable: false),
                    IdMount = table.Column<long>(type: "bigint", nullable: false),
                    Nama = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Sku = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    Harga = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    JumlahStok = table.Column<int>(type: "integer", nullable: false),
                    PanjangFokusMin = table.Column<int>(type: "integer", nullable: false),
                    PanjangFokusMaks = table.Column<int>(type: "integer", nullable: false),
                    BukaanMaksimal = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UrlGambar = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lensa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lensa_Kategori_Produk_IdKategori",
                        column: x => x.IdKategori,
                        principalTable: "Kategori_Produk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lensa_Merek_IdMerek",
                        column: x => x.IdMerek,
                        principalTable: "Merek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lensa_Tipe_Mount_IdMount",
                        column: x => x.IdMount,
                        principalTable: "Tipe_Mount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alamat",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPengguna = table.Column<long>(type: "bigint", nullable: false),
                    LabelAlamat = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NamaPenerima = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DetailJalan = table.Column<string>(type: "text", nullable: false),
                    Kota = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    KodePos = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    AlamatUtama = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alamat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alamat_User_IdPengguna",
                        column: x => x.IdPengguna,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spek_Kamera",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdKamera = table.Column<long>(type: "bigint", nullable: false),
                    TahunRilis = table.Column<int>(type: "integer", nullable: false),
                    Resolusi = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TipeSensor = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Prosesor = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    JumlahTitikFokus = table.Column<int>(type: "integer", nullable: false),
                    PunyaAutofocusSubjek = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spek_Kamera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spek_Kamera_Kamera_IdKamera",
                        column: x => x.IdKamera,
                        principalTable: "Kamera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ulasan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPengguna = table.Column<long>(type: "bigint", nullable: false),
                    IdKamera = table.Column<long>(type: "bigint", nullable: true),
                    IdLensa = table.Column<long>(type: "bigint", nullable: true),
                    Peringkat = table.Column<int>(type: "integer", nullable: false),
                    Komentar = table.Column<string>(type: "text", nullable: false),
                    DibuatPada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulasan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ulasan_Kamera_IdKamera",
                        column: x => x.IdKamera,
                        principalTable: "Kamera",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ulasan_Lensa_IdLensa",
                        column: x => x.IdLensa,
                        principalTable: "Lensa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ulasan_User_IdPengguna",
                        column: x => x.IdPengguna,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pesanan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPengguna = table.Column<long>(type: "bigint", nullable: false),
                    IdAlamatPengiriman = table.Column<long>(type: "bigint", nullable: false),
                    TanggalPesanan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    JumlahTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesanan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pesanan_Alamat_IdAlamatPengiriman",
                        column: x => x.IdAlamatPengiriman,
                        principalTable: "Alamat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pesanan_User_IdPengguna",
                        column: x => x.IdPengguna,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detail_Pesanan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPesanan = table.Column<long>(type: "bigint", nullable: false),
                    IdKamera = table.Column<long>(type: "bigint", nullable: true),
                    IdLensa = table.Column<long>(type: "bigint", nullable: true),
                    Kuantitas = table.Column<int>(type: "integer", nullable: false),
                    HargaSaatPembelian = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail_Pesanan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detail_Pesanan_Kamera_IdKamera",
                        column: x => x.IdKamera,
                        principalTable: "Kamera",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Detail_Pesanan_Lensa_IdLensa",
                        column: x => x.IdLensa,
                        principalTable: "Lensa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Detail_Pesanan_Pesanan_IdPesanan",
                        column: x => x.IdPesanan,
                        principalTable: "Pesanan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alamat_IdPengguna",
                table: "Alamat",
                column: "IdPengguna");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Pesanan_IdKamera",
                table: "Detail_Pesanan",
                column: "IdKamera");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Pesanan_IdLensa",
                table: "Detail_Pesanan",
                column: "IdLensa");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Pesanan_IdPesanan",
                table: "Detail_Pesanan",
                column: "IdPesanan");

            migrationBuilder.CreateIndex(
                name: "IX_Kamera_IdKategori",
                table: "Kamera",
                column: "IdKategori");

            migrationBuilder.CreateIndex(
                name: "IX_Kamera_IdMerek",
                table: "Kamera",
                column: "IdMerek");

            migrationBuilder.CreateIndex(
                name: "IX_Kamera_IdMount",
                table: "Kamera",
                column: "IdMount");

            migrationBuilder.CreateIndex(
                name: "IX_Lensa_IdKategori",
                table: "Lensa",
                column: "IdKategori");

            migrationBuilder.CreateIndex(
                name: "IX_Lensa_IdMerek",
                table: "Lensa",
                column: "IdMerek");

            migrationBuilder.CreateIndex(
                name: "IX_Lensa_IdMount",
                table: "Lensa",
                column: "IdMount");

            migrationBuilder.CreateIndex(
                name: "IX_Pesanan_IdAlamatPengiriman",
                table: "Pesanan",
                column: "IdAlamatPengiriman");

            migrationBuilder.CreateIndex(
                name: "IX_Pesanan_IdPengguna",
                table: "Pesanan",
                column: "IdPengguna");

            migrationBuilder.CreateIndex(
                name: "IX_Spek_Kamera_IdKamera",
                table: "Spek_Kamera",
                column: "IdKamera",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ulasan_IdKamera",
                table: "Ulasan",
                column: "IdKamera");

            migrationBuilder.CreateIndex(
                name: "IX_Ulasan_IdLensa",
                table: "Ulasan",
                column: "IdLensa");

            migrationBuilder.CreateIndex(
                name: "IX_Ulasan_IdPengguna",
                table: "Ulasan",
                column: "IdPengguna");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detail_Pesanan");

            migrationBuilder.DropTable(
                name: "Spek_Kamera");

            migrationBuilder.DropTable(
                name: "Ulasan");

            migrationBuilder.DropTable(
                name: "Pesanan");

            migrationBuilder.DropTable(
                name: "Kamera");

            migrationBuilder.DropTable(
                name: "Lensa");

            migrationBuilder.DropTable(
                name: "Alamat");

            migrationBuilder.DropTable(
                name: "Kategori_Produk");

            migrationBuilder.DropTable(
                name: "Merek");

            migrationBuilder.DropTable(
                name: "Tipe_Mount");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
