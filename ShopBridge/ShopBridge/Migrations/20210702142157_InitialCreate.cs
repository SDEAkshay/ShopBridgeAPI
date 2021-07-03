using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopBridge.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Mobiles" },
                    { 2, "Laptops" },
                    { 3, "TV" },
                    { 4, "Cameras" },
                    { 5, "Music Instruments" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "PhotoPath", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "OnePlus Nord CE 5G (Charcoal Ink, 8GB RAM, 128GB Storage)", "images/oneplus.png", 24999.00m, "OnePlus", 3 },
                    { 2, 1, "OnePlus 9R 5G (Lake Blue, 8GB RAM, 128GB Storage)", "images/oneplus9R.png", 39999.00m, "OnePlus", 5 },
                    { 3, 2, "Acer Nitro 5 Intel Core i5-11th Generation 144 Hz Refresh Rate 15.6-inch (39.62 cms) Gaming Laptop (8GB Ram/512 GB SSD/Win10/GTX 1650 Graphics/Obsidian Black/2.2 Kgs), AN515-56 + Xbox Game Pass for PC", "images/Acer.png", 72994.00m, "Acer Nitro", 3 },
                    { 4, 2, "2020 Apple MacBook Pro (13.3-inch/33.78 cm, 8GB RAM, 256GB SSD, 1.4GHz Quad-core 8th-Generation Intel Core i5 Processor, Two Thunderbolt 3 Ports) - Space Grey", "images/Apple.png", 99990.00m, "Apple MacBook Pro", 10 },
                    { 7, 3, "Samsung 138 cm (55 inches) Crystal 4K Pro Series Ultra HD Smart LED TV UA55AUE70AKLXL (Black) (2021 Model)", "images/TV.png", 54999.00m, "Samsung Smart TV", 2 },
                    { 8, 4, "Sony Alpha ILCE-6400M 24.2MP Mirrorless Digital SLR Camera (Black) with 18-135mm Power Zoom Lens (APS-C Sensor, Real-Time Eye Auto Focus, 4K Vlogging Camera, Tiltable LCD) - Black", "images/SonyCamera.png", 102499.00m, "Sony Microless Camera", 5 },
                    { 9, 4, "Canon EOS 200D II 24.1MP Digital SLR Camera + EF-S 18-55mm is STM Lens + EF-S 55-250mm is STM Lens (Black)", "images/Canon.png", 62220.00m, "Canon Camera", 3 },
                    { 5, 5, "Casio CT-S200 Casiotone 61-Key Portable Keyboard (Red)", "images/Casio.png", 7595.00m, "Casio", 7 },
                    { 6, 5, "Ashton D10C 39-inch Cutaway Acoustic Guitar", "images/Guitar.png", 7595.00m, "Guitar", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
