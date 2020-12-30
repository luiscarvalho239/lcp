using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;
using MyApiWeb.Functions;
using System;
using Microsoft.Extensions.Configuration;
using MyApiWeb.Models;

namespace MyApiWeb.Models
{
    public class AllDBContext : DbContext
    {
        private readonly IConfiguration _config;

        public AllDBContext(IConfiguration config, DbContextOptions<AllDBContext> options) : base(options) 
        {
          _config = config;
        }

        public DbSet<Users> UsersItems { get; set; }
        public DbSet<RadiosList> RadiosListItems { get; set; }
        public DbSet<News> NewsItems { get; set; }
        public DbSet<Videos> VideosItems { get; set; }
        public DbSet<Games> GamesItems { get; set; }
        public DbSet<SaveGames> SaveGamesItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          var apiurl = "https://localhost:5001";
          DateTime dt = DateTime.UtcNow.AddDays(7);

          builder.Entity<Users>().HasData(
            new Users() {
              Id = 1,
              Username = "luis",
              Password = BC.HashPassword("luis1234"),
              Email = "luis@local.loc",
              Image = apiurl+"/resources/images/luis.jpg",
              FirstName = "Luis",
              LastName = "Carvalho",
              Role = "admin",
              Token = MyFunctions.BuildToken(_config, "luis", dt)
            },
            new Users()
            {
              Id = 2,
              Username = "guest",
              Password = BC.HashPassword("guest1234"),
              Email = "guest@local.loc",
              Image = apiurl + "/resources/images/guest.png",
              FirstName = "Guest",
              LastName = "G",
              Role = "guest",
              Token = MyFunctions.BuildToken(_config, "guest", dt)
            },
            new Users()
            {
              Id = 3,
              Username = "goku",
              Password = BC.HashPassword("goku1234"),
              Email = "goku@local.loc",
              Image = apiurl + "/resources/images/goku.png",
              FirstName = "Son",
              LastName = "Goku",
              Role = "user",
              Token = MyFunctions.BuildToken(_config, "goku", dt)
            },
            new Users()
            {
              Id = 4,
              Username = "danny_phantom",
              Password = BC.HashPassword("danny1234"),
              Email = "danny_phantom@local.loc",
              Image = apiurl + "/resources/images/danny.png",
              FirstName = "Danny",
              LastName = "Phantom",
              Role = "user",
              Token = MyFunctions.BuildToken(_config, "danny_phantom", dt)
            },
            new Users()
            {
              Id = 5,
              Username = "jimmy_neutron",
              Password = BC.HashPassword("jimmy1234"),
              Email = "jimmy_neutron@local.loc",
              Image = apiurl + "/resources/images/jimmy.jpg",
              FirstName = "Jimmy",
              LastName = "Neutron",
              Role = "user",
              Token = MyFunctions.BuildToken(_config, "jimmy_neutron", dt)
            },
            new Users()
            {
              Id = 6,
              Username = "timmy_turner",
              Password = BC.HashPassword("timmy1234"),
              Email = "timmy_turner@local.loc",
              Image = apiurl + "/resources/images/timmy.png",
              FirstName = "Timmy",
              LastName = "Turner",
              Role = "user",
              Token = MyFunctions.BuildToken(_config, "timmy_turner", dt)
            },
            new Users()
            {
              Id = 7,
              Username = "ironman",
              Password = BC.HashPassword("ironman1234"),
              Email = "iron_man@local.loc",
              Image = apiurl + "/resources/images/ironman.jpg",
              FirstName = "Iron",
              LastName = "Man",
              Role = "user",
              Token = MyFunctions.BuildToken(_config, "ironman", dt)
            }
          );

          builder.Entity<RadiosList>().HasData(
            new RadiosList()
            {
              Id = 1,
              RadioTitle = "M80",
              RadioSrc = "http://mcrscast.mcr.iol.pt/m80",
              RadioImage = apiurl + "/resources/images/radios/m80.jpg"
            }
          );

          builder.Entity<News>().HasData(
            new News()
            {
              Id = 1,
              Title = "Noticia 1",
              Desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.",
              Date = DateTime.UtcNow,
              Cover = "assets/images/cover.jpg",
              Category = "Exemplo",
              Text = "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: yellow;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>",
              Source = "/news/1",
              UsersId = 1
            },
            new News()
            {
              Id = 2,
              Title = "Noticia 2",
              Desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.",
              Date = DateTime.UtcNow,
              Cover = "assets/images/cover.jpg",
              Category = "Exemplo",
              Text = "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: orange;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>",
              Source = "/news/2",
              UsersId = 1
            },
            new News()
            {
              Id = 3,
              Title = "Noticia 3",
              Desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.",
              Date = DateTime.UtcNow,
              Cover = "assets/images/cover.jpg",
              Category = "Exemplo",
              Text = "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: lightblue;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>",
              Source = "/news/3",
              UsersId = 1
            },
            new News()
            {
              Id = 4,
              Title = "Noticia 4",
              Desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.",
              Date = DateTime.UtcNow,
              Cover = "assets/images/cover.jpg",
              Category = "Exemplo",
              Text = "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: orange;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>",
              Source = "/news/4",
              UsersId = 1
            },
            new News()
            {
              Id = 5,
              Title = "Noticia 5",
              Desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.",
              Date = DateTime.UtcNow,
              Cover = "assets/images/cover.jpg",
              Category = "Exemplo",
              Text = "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: yellow;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>",
              Source = "/news/5",
              UsersId = 1
            },
            new News()
            {
              Id = 6,
              Title = "Noticia 6",
              Desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.",
              Date = DateTime.UtcNow,
              Cover = "assets/images/cover.jpg",
              Category = "Exemplo",
              Text = "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: orange;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>",
              Source = "/news/6",
              UsersId = 1
            }
          );

          builder.Entity<Videos>().HasData(
            new Videos()
            {
              Id = 1,
              Src = apiurl + "/resources/videos/v1.mp4",
              Type = "video/mp4"
            },
            new Videos()
            {
              Id = 2,
              Src = apiurl + "/resources/videos/v2.mp4",
              Type = "video/mp4"
            },
            new Videos()
            {
              Id = 3,
              Src = apiurl + "/resources/videos/v3.mp4",
              Type = "video/mp4"
            }
          );

          builder.Entity<Games>().HasData(
            new Games()
            {
              Id = 1,
              Title = "GTA V",
              Desc = "GTA V",
              Cover = apiurl + "/resources/images/games/gtav.jpg",
              Platforms = "PS3,X360,PS3,XONE,PS4,PC,PS5,XSERIES X|S",
              Platform_used = "PC",
              Developer = "Rockstar North",
              Publisher = "Rockstar Games",
              Genre = "Action and Adventure",
              Release_date = new System.DateTime(2017, 9, 13, 0, 0, 0),
              UsersId = 1
            }
          );

          builder.Entity<SaveGames>().HasData(
            new SaveGames() {
              Id = 1,
              Title = "Prologue",
              Is_req_to_100 = true,
              Type_medal = "Gold",
              File_img = apiurl + "/resources/images/games/gtav.jpg",
              File_url = "https://gtasnp.com/v-prologue",
              GamesId = 1,
              UsersId = 1
            }
          );

          base.OnModelCreating(builder);
        }
  }
}
