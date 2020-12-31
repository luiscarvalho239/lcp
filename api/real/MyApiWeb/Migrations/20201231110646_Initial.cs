using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApiWeb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    platforms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    platform_used = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    developer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RadiosList",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    radiotitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    radiosrc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    radioimage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadiosList", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SaveGames",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    is_req_to_100 = table.Column<bool>(type: "bit", nullable: false),
                    type_medal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gamesId = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveGames", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "id", "cover", "desc", "developer", "genre", "platform_used", "platforms", "publisher", "release_date", "title", "usersId" },
                values: new object[] { 1, "https://localhost:5001/resources/images/games/gtav.jpg", "GTA V", "Rockstar North", "Action and Adventure", "PC", "PS3,X360,PS3,XONE,PS4,PC,PS5,XSERIES X|S", "Rockstar Games", new DateTime(2017, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "GTA V", 1 });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "id", "category", "cover", "date", "desc", "source", "text", "title", "usersId" },
                values: new object[,]
                {
                    { 1, "Exemplo", "assets/images/cover.jpg", new DateTime(2020, 12, 31, 11, 6, 46, 544, DateTimeKind.Utc).AddTicks(404), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.", "/news/1", "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: yellow;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>", "Noticia 1", 1 },
                    { 2, "Exemplo", "assets/images/cover.jpg", new DateTime(2020, 12, 31, 11, 6, 46, 544, DateTimeKind.Utc).AddTicks(1738), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.", "/news/2", "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: orange;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>", "Noticia 2", 1 },
                    { 3, "Exemplo", "assets/images/cover.jpg", new DateTime(2020, 12, 31, 11, 6, 46, 544, DateTimeKind.Utc).AddTicks(1742), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.", "/news/3", "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: lightblue;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>", "Noticia 3", 1 },
                    { 4, "Exemplo", "assets/images/cover.jpg", new DateTime(2020, 12, 31, 11, 6, 46, 544, DateTimeKind.Utc).AddTicks(1744), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.", "/news/4", "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: orange;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>", "Noticia 4", 1 },
                    { 5, "Exemplo", "assets/images/cover.jpg", new DateTime(2020, 12, 31, 11, 6, 46, 544, DateTimeKind.Utc).AddTicks(1746), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.", "/news/5", "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: yellow;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>", "Noticia 5", 1 },
                    { 6, "Exemplo", "assets/images/cover.jpg", new DateTime(2020, 12, 31, 11, 6, 46, 544, DateTimeKind.Utc).AddTicks(1748), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.", "/news/6", "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: orange;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>", "Noticia 6", 1 }
                });

            migrationBuilder.InsertData(
                table: "RadiosList",
                columns: new[] { "id", "radioimage", "radiosrc", "radiotitle" },
                values: new object[] { 1, "https://localhost:5001/resources/images/radios/m80.jpg", "http://mcrscast.mcr.iol.pt/m80", "M80" });

            migrationBuilder.InsertData(
                table: "SaveGames",
                columns: new[] { "id", "file_img", "file_url", "gamesId", "is_req_to_100", "title", "type_medal", "usersId" },
                values: new object[] { 1, "https://localhost:5001/resources/images/games/gtav.jpg", "https://gtasnp.com/v-prologue", 1, true, "Prologue", "Gold", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "firstName", "image", "lastName", "password", "role", "token", "username" },
                values: new object[,]
                {
                    { 7, "iron_man@local.loc", "Iron", "https://localhost:5001/resources/images/ironman.jpg", "Man", "$2a$11$H3FX8Jvyg1EJBhf0lybBi.k.q.WTUV0En9PXTebfyI2ezECD/s9pu", "user", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Imlyb25tYW4iLCJqdGkiOiI4Zjk0MGNkMi05OWU2LTQyOGItYTQ1Yy1jMDIyYzQ1NmQ4ZmYiLCJleHAiOjE2MTAwMTc2MDUsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.WIrheMS0FJTL0G8v_wxW9TbkaU2R-yZN0vhyRj6w5bY", "ironman" },
                    { 6, "timmy_turner@local.loc", "Timmy", "https://localhost:5001/resources/images/timmy.png", "Turner", "$2a$11$qoDJzk7Y33j9YO32EuUsUeZjBcdWQtf3qrha8RmFpV/fBRFaltQtu", "user", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRpbW15X3R1cm5lciIsImp0aSI6IjgxYmVlNzIwLTVhOGMtNDNlNC1iMDg5LWI0NWZiZjc2N2U2OCIsImV4cCI6MTYxMDAxNzYwNSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMSIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEifQ.zdwU5bbz527OMLR_1A8RBIUG-IQrMosvxjfbwI740t8", "timmy_turner" },
                    { 5, "jimmy_neutron@local.loc", "Jimmy", "https://localhost:5001/resources/images/jimmy.jpg", "Neutron", "$2a$11$pKZ8ulrzZLk7MlM4agwElepWp4fQaBDyD3hKJ4mcOM3w63ZQIyXa6", "user", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImppbW15X25ldXRyb24iLCJqdGkiOiI0YjVjOGQ3Yy01YTVhLTRhMDQtOGRlYS1lY2YwZTg1MDQ1Y2QiLCJleHAiOjE2MTAwMTc2MDUsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.Nh0BN86uCvxQgBbyX245iQa1fuJspXkbKWZ89H1pLik", "jimmy_neutron" },
                    { 1, "luis@local.loc", "Luis", "https://localhost:5001/resources/images/luis.jpg", "Carvalho", "$2a$11$203u39ttCbbhgWL7SUSva.izBIXKYZfeom97S1fkTECIGc4YANeWK", "admin", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Imx1aXMiLCJqdGkiOiIxMzg2MTI1ZS0zOGQ0LTQ4MzItYjE2Yy05NjExOWU0YzQ1MTciLCJleHAiOjE2MTAwMTc2MDUsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.tEGfasMoeiKJMbnKbWdKiNYC3x3uLP73gjPx7cKon8o", "luis" },
                    { 3, "goku@local.loc", "Son", "https://localhost:5001/resources/images/goku.png", "Goku", "$2a$11$Q6EoiQARqEHHqCUF3QpQ6Ow8LeHg5aLGUPijsynC9bKEaFmoIBMuS", "user", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Imdva3UiLCJqdGkiOiIyYjIxZDI4OC1kZGEyLTQwNzAtYTNkZi1lNzNjYTkzNmZiZDUiLCJleHAiOjE2MTAwMTc2MDUsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.fnaJZe-LR5y9HwjVhq2tv-MceF59vZmMgN5NTJ__Y_I", "goku" },
                    { 2, "guest@local.loc", "Guest", "https://localhost:5001/resources/images/guest.png", "G", "$2a$11$L2dGcMclDLSieiMqwZXgq.RIjKIzHqFjWgLlBRRUCffrYZ4jEy37q", "guest", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Imd1ZXN0IiwianRpIjoiZTJiOTBiMDMtZjA5Ny00NzhiLWE2YWMtZDNlM2IwZGE3OGEzIiwiZXhwIjoxNjEwMDE3NjA1LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMSJ9.zAcub0KdTcLiTv0_EWtmhR8TM5omV9K9lgUrZJyHIyE", "guest" },
                    { 4, "danny_phantom@local.loc", "Danny", "https://localhost:5001/resources/images/danny.png", "Phantom", "$2a$11$UAJkaqpYxyG8FwYJ3TOtaun/Rt/sMFzs/9CJCedxvEr2c8sgOazMO", "user", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImRhbm55X3BoYW50b20iLCJqdGkiOiJhZjY4MzAxOS1mZDVhLTRmMjctYWM1OS1iNjllYTkwNGYzNmQiLCJleHAiOjE2MTAwMTc2MDUsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.toAkGMZ9KuzFXgoVAgRmJdrwAGOj_voBUeXTQ5qjSZI", "danny_phantom" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "id", "src", "type" },
                values: new object[,]
                {
                    { 2, "https://localhost:5001/resources/videos/v2.mp4", "video/mp4" },
                    { 1, "https://localhost:5001/resources/videos/v1.mp4", "video/mp4" },
                    { 3, "https://localhost:5001/resources/videos/v3.mp4", "video/mp4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "RadiosList");

            migrationBuilder.DropTable(
                name: "SaveGames");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
