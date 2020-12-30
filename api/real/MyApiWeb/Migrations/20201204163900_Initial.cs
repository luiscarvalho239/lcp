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
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(maxLength: 255, nullable: false),
                    desc = table.Column<string>(nullable: true),
                    platforms = table.Column<string>(nullable: true),
                    platform_used = table.Column<string>(nullable: true),
                    genre = table.Column<string>(nullable: true),
                    release_date = table.Column<DateTime>(nullable: false),
                    publisher = table.Column<string>(nullable: true),
                    developer = table.Column<string>(nullable: true),
                    cover = table.Column<string>(nullable: true),
                    usersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(maxLength: 255, nullable: false),
                    desc = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    cover = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    text = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    usersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RadiosList",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    radiotitle = table.Column<string>(nullable: false),
                    radiosrc = table.Column<string>(nullable: false),
                    radioimage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadiosList", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SaveGames",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(maxLength: 255, nullable: false),
                    is_req_to_100 = table.Column<bool>(nullable: false),
                    type_medal = table.Column<string>(nullable: true),
                    file_img = table.Column<string>(nullable: true),
                    file_url = table.Column<string>(nullable: true),
                    gamesId = table.Column<int>(nullable: false),
                    usersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveGames", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    role = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    src = table.Column<string>(nullable: false),
                    type = table.Column<string>(nullable: true)
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
                    { 1, "Exemplo", "assets/images/cover.jpg", new DateTime(2020, 12, 4, 16, 39, 0, 457, DateTimeKind.Utc).AddTicks(429), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.", "/news/1", "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: yellow;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>", "Noticia 1", 1 },
                    { 2, "Exemplo", "assets/images/cover.jpg", new DateTime(2020, 12, 4, 16, 39, 0, 457, DateTimeKind.Utc).AddTicks(2733), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.", "/news/2", "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: orange;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>", "Noticia 2", 1 },
                    { 3, "Exemplo", "assets/images/cover.jpg", new DateTime(2020, 12, 4, 16, 39, 0, 457, DateTimeKind.Utc).AddTicks(2775), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.", "/news/3", "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: lightblue;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>", "Noticia 3", 1 },
                    { 4, "Exemplo", "assets/images/cover.jpg", new DateTime(2020, 12, 4, 16, 39, 0, 457, DateTimeKind.Utc).AddTicks(2777), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.", "/news/4", "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: orange;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>", "Noticia 4", 1 },
                    { 5, "Exemplo", "assets/images/cover.jpg", new DateTime(2020, 12, 4, 16, 39, 0, 457, DateTimeKind.Utc).AddTicks(2778), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.", "/news/5", "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: yellow;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>", "Noticia 5", 1 },
                    { 6, "Exemplo", "assets/images/cover.jpg", new DateTime(2020, 12, 4, 16, 39, 0, 457, DateTimeKind.Utc).AddTicks(2779), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.", "/news/6", "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: orange;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>", "Noticia 6", 1 }
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
                    { 7, "iron_man@local.loc", "Iron", "https://localhost:5001/resources/images/ironman.jpg", "Man", "$2a$11$VikNw3yntQ9Hi1nHxFgx0eEnzGYGsu8bDD970Gl.ic4YwmyASU.3C", "user", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Imlyb25tYW4iLCJqdGkiOiIwYjUwMDAzYy04Mzk0LTQyOTEtYmM2Zi1hZjNkYWNkYjA3MTkiLCJleHAiOjE2MDc3MDQ3MzksImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.0XHyqsKZE9xMAvC5vo60dlCghJ5eUPCqUwXr3NmoCNc", "ironman" },
                    { 6, "timmy_turner@local.loc", "Timmy", "https://localhost:5001/resources/images/timmy.png", "Turner", "$2a$11$XbZ.RL7IvfFk82LEVcEC..7GwYbDrEI2O1/xztSo3E4637B0N1cM2", "user", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRpbW15X3R1cm5lciIsImp0aSI6IjBiOWQ2MTliLTAwYmQtNGExOC1hYmRiLTJhNjY5YTRhMjI4MCIsImV4cCI6MTYwNzcwNDczOSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMSIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEifQ.GCjRGOsc8i3oHFswy2b5-v76QI3PDHpotNce7Y1F0Pc", "timmy_turner" },
                    { 5, "jimmy_neutron@local.loc", "Jimmy", "https://localhost:5001/resources/images/jimmy.jpg", "Neutron", "$2a$11$Lm3jU34IOFLah.i16OfHZuqAK2sQqE2ewKGNFS/JMOZ0yY9lOqcHi", "user", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImppbW15X25ldXRyb24iLCJqdGkiOiI1NGU2NTdmYy1lZTI5LTQ4YzktYWM0ZS0yYTQ5NWJiN2RiOTYiLCJleHAiOjE2MDc3MDQ3MzksImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.6Aag7e9UKaxVSWRWoGQL-hxBcJHKa-z55SZe75IjezM", "jimmy_neutron" },
                    { 1, "luis@local.loc", "Luis", "https://localhost:5001/resources/images/luis.jpg", "Carvalho", "$2a$11$MBdIjKpMNKvW3TTaQ0rhPOfAsTmpesa1Lt718Vg4ozGhJJEq5YO.S", "admin", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Imx1aXMiLCJqdGkiOiI1ZDZiNDg4MS1mM2I4LTRkMjQtYThlYy1kZDQ1ZmNkZTZlMTciLCJleHAiOjE2MDc3MDQ3MzksImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.eJN2qSRmTDlHxgUJVWGe9UyXJ9EQHpUFdgeoZyFcNk8", "luis" },
                    { 3, "goku@local.loc", "Son", "https://localhost:5001/resources/images/goku.png", "Goku", "$2a$11$dqf7gh6L8MlTFphbreDLBelVDD82UEg3r6P1mvpyka/mE.BlIkCpC", "user", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Imdva3UiLCJqdGkiOiJmNDk2NTE1My01ZWRkLTRjODAtYTJmYS1iYzZiN2QzN2M4MmEiLCJleHAiOjE2MDc3MDQ3MzksImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.vYzL2yT-l5n5HEcYGRQC91ExAzTopGLXAQMWkZprF1M", "goku" },
                    { 2, "guest@local.loc", "Guest", "https://localhost:5001/resources/images/guest.png", "G", "$2a$11$XIFuKvD/OTKfMoZpqan3Wui8m6P8gPqP0EUdleAXjy8tA5NyTXFPS", "guest", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Imd1ZXN0IiwianRpIjoiMGVhYjYyOTEtN2Q2NS00NjkyLTg2NjgtZjk1Y2I5MjhlNWNmIiwiZXhwIjoxNjA3NzA0NzM5LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMSJ9.8jucFIGU8B-pzFXEohkE660m76T8hhH7kdUkInZI20k", "guest" },
                    { 4, "danny_phantom@local.loc", "Danny", "https://localhost:5001/resources/images/danny.png", "Phantom", "$2a$11$fPaEnzaegVBH.5mnk.gEU.zYGVuaLFwuscQK7kWVcgIfgD7SPGluS", "user", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImRhbm55X3BoYW50b20iLCJqdGkiOiJiNDQwZDZmYi1lMGI1LTQ1MWItYWFhZi0zZDEzYTFlYzU1MzciLCJleHAiOjE2MDc3MDQ3MzksImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.oTHERFsetwW9sSczzrhv4INUS66PrEGzVEQmvyEqQ1U", "danny_phantom" }
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
