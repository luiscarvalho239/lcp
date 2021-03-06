﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApiWeb.Models;

namespace MyApiWeb.Migrations
{
    [DbContext(typeof(AllDBContext))]
    partial class AllDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MyApiWeb.Models.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("Cover")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cover");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("desc");

                    b.Property<string>("Developer")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("developer");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("genre");

                    b.Property<string>("Platform_used")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("platform_used");

                    b.Property<string>("Platforms")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("platforms");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("publisher");

                    b.Property<DateTime>("Release_date")
                        .HasColumnType("datetime2")
                        .HasColumnName("release_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("title");

                    b.Property<int>("UsersId")
                        .HasColumnType("int")
                        .HasColumnName("usersId");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cover = "https://localhost:5001/resources/images/games/gtav.jpg",
                            Desc = "GTA V",
                            Developer = "Rockstar North",
                            Genre = "Action and Adventure",
                            Platform_used = "PC",
                            Platforms = "PS3,X360,PS3,XONE,PS4,PC,PS5,XSERIES X|S",
                            Publisher = "Rockstar Games",
                            Release_date = new DateTime(2017, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "GTA V",
                            UsersId = 1
                        });
                });

            modelBuilder.Entity("MyApiWeb.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("category");

                    b.Property<string>("Cover")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cover");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("desc");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("source");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("title");

                    b.Property<int>("UsersId")
                        .HasColumnType("int")
                        .HasColumnName("usersId");

                    b.HasKey("Id");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Exemplo",
                            Cover = "assets/images/cover.jpg",
                            Date = new DateTime(2020, 12, 31, 11, 6, 46, 544, DateTimeKind.Utc).AddTicks(404),
                            Desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.",
                            Source = "/news/1",
                            Text = "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: yellow;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>",
                            Title = "Noticia 1",
                            UsersId = 1
                        },
                        new
                        {
                            Id = 2,
                            Category = "Exemplo",
                            Cover = "assets/images/cover.jpg",
                            Date = new DateTime(2020, 12, 31, 11, 6, 46, 544, DateTimeKind.Utc).AddTicks(1738),
                            Desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.",
                            Source = "/news/2",
                            Text = "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: orange;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>",
                            Title = "Noticia 2",
                            UsersId = 1
                        },
                        new
                        {
                            Id = 3,
                            Category = "Exemplo",
                            Cover = "assets/images/cover.jpg",
                            Date = new DateTime(2020, 12, 31, 11, 6, 46, 544, DateTimeKind.Utc).AddTicks(1742),
                            Desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.",
                            Source = "/news/3",
                            Text = "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: lightblue;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>",
                            Title = "Noticia 3",
                            UsersId = 1
                        },
                        new
                        {
                            Id = 4,
                            Category = "Exemplo",
                            Cover = "assets/images/cover.jpg",
                            Date = new DateTime(2020, 12, 31, 11, 6, 46, 544, DateTimeKind.Utc).AddTicks(1744),
                            Desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.",
                            Source = "/news/4",
                            Text = "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: orange;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>",
                            Title = "Noticia 4",
                            UsersId = 1
                        },
                        new
                        {
                            Id = 5,
                            Category = "Exemplo",
                            Cover = "assets/images/cover.jpg",
                            Date = new DateTime(2020, 12, 31, 11, 6, 46, 544, DateTimeKind.Utc).AddTicks(1746),
                            Desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.",
                            Source = "/news/5",
                            Text = "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: yellow;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>",
                            Title = "Noticia 5",
                            UsersId = 1
                        },
                        new
                        {
                            Id = 6,
                            Category = "Exemplo",
                            Cover = "assets/images/cover.jpg",
                            Date = new DateTime(2020, 12, 31, 11, 6, 46, 544, DateTimeKind.Utc).AddTicks(1748),
                            Desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.",
                            Source = "/news/6",
                            Text = "<p class='t-justify'>Lorem ipsum dolor sit amet, <b style='background-color: orange;'>consectetur adipiscing elit</b>. Suspendisse lobortis vitae elit id sagittis. Integer maximus leo in dapibus feugiat. Duis nulla orci, consequat in lobortis vel, condimentum vel turpis. Morbi quis tincidunt enim. Nunc finibus mi felis. Sed lobortis ornare dui, sit amet consequat felis. Suspendisse id orci accumsan, tincidunt quam ultrices, fringilla turpis.</p><p>Youtube video: </p><iframe width='560' height='315' src='https://www.youtube-nocookie.com/embed/azdwsXLmrHE' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>",
                            Title = "Noticia 6",
                            UsersId = 1
                        });
                });

            modelBuilder.Entity("MyApiWeb.Models.RadiosList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("RadioImage")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("radioimage");

                    b.Property<string>("RadioSrc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("radiosrc");

                    b.Property<string>("RadioTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("radiotitle");

                    b.HasKey("Id");

                    b.ToTable("RadiosList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RadioImage = "https://localhost:5001/resources/images/radios/m80.jpg",
                            RadioSrc = "http://mcrscast.mcr.iol.pt/m80",
                            RadioTitle = "M80"
                        });
                });

            modelBuilder.Entity("MyApiWeb.Models.SaveGames", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("File_img")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("file_img");

                    b.Property<string>("File_url")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("file_url");

                    b.Property<int>("GamesId")
                        .HasColumnType("int")
                        .HasColumnName("gamesId");

                    b.Property<bool>("Is_req_to_100")
                        .HasColumnType("bit")
                        .HasColumnName("is_req_to_100");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("title");

                    b.Property<string>("Type_medal")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("type_medal");

                    b.Property<int>("UsersId")
                        .HasColumnType("int")
                        .HasColumnName("usersId");

                    b.HasKey("Id");

                    b.ToTable("SaveGames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            File_img = "https://localhost:5001/resources/images/games/gtav.jpg",
                            File_url = "https://gtasnp.com/v-prologue",
                            GamesId = 1,
                            Is_req_to_100 = true,
                            Title = "Prologue",
                            Type_medal = "Gold",
                            UsersId = 1
                        });
                });

            modelBuilder.Entity("MyApiWeb.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("firstName");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("token");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "luis@local.loc",
                            FirstName = "Luis",
                            Image = "https://localhost:5001/resources/images/luis.jpg",
                            LastName = "Carvalho",
                            Password = "$2a$11$203u39ttCbbhgWL7SUSva.izBIXKYZfeom97S1fkTECIGc4YANeWK",
                            Role = "admin",
                            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Imx1aXMiLCJqdGkiOiIxMzg2MTI1ZS0zOGQ0LTQ4MzItYjE2Yy05NjExOWU0YzQ1MTciLCJleHAiOjE2MTAwMTc2MDUsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.tEGfasMoeiKJMbnKbWdKiNYC3x3uLP73gjPx7cKon8o",
                            Username = "luis"
                        },
                        new
                        {
                            Id = 2,
                            Email = "guest@local.loc",
                            FirstName = "Guest",
                            Image = "https://localhost:5001/resources/images/guest.png",
                            LastName = "G",
                            Password = "$2a$11$L2dGcMclDLSieiMqwZXgq.RIjKIzHqFjWgLlBRRUCffrYZ4jEy37q",
                            Role = "guest",
                            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Imd1ZXN0IiwianRpIjoiZTJiOTBiMDMtZjA5Ny00NzhiLWE2YWMtZDNlM2IwZGE3OGEzIiwiZXhwIjoxNjEwMDE3NjA1LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMSJ9.zAcub0KdTcLiTv0_EWtmhR8TM5omV9K9lgUrZJyHIyE",
                            Username = "guest"
                        },
                        new
                        {
                            Id = 3,
                            Email = "goku@local.loc",
                            FirstName = "Son",
                            Image = "https://localhost:5001/resources/images/goku.png",
                            LastName = "Goku",
                            Password = "$2a$11$Q6EoiQARqEHHqCUF3QpQ6Ow8LeHg5aLGUPijsynC9bKEaFmoIBMuS",
                            Role = "user",
                            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Imdva3UiLCJqdGkiOiIyYjIxZDI4OC1kZGEyLTQwNzAtYTNkZi1lNzNjYTkzNmZiZDUiLCJleHAiOjE2MTAwMTc2MDUsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.fnaJZe-LR5y9HwjVhq2tv-MceF59vZmMgN5NTJ__Y_I",
                            Username = "goku"
                        },
                        new
                        {
                            Id = 4,
                            Email = "danny_phantom@local.loc",
                            FirstName = "Danny",
                            Image = "https://localhost:5001/resources/images/danny.png",
                            LastName = "Phantom",
                            Password = "$2a$11$UAJkaqpYxyG8FwYJ3TOtaun/Rt/sMFzs/9CJCedxvEr2c8sgOazMO",
                            Role = "user",
                            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImRhbm55X3BoYW50b20iLCJqdGkiOiJhZjY4MzAxOS1mZDVhLTRmMjctYWM1OS1iNjllYTkwNGYzNmQiLCJleHAiOjE2MTAwMTc2MDUsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.toAkGMZ9KuzFXgoVAgRmJdrwAGOj_voBUeXTQ5qjSZI",
                            Username = "danny_phantom"
                        },
                        new
                        {
                            Id = 5,
                            Email = "jimmy_neutron@local.loc",
                            FirstName = "Jimmy",
                            Image = "https://localhost:5001/resources/images/jimmy.jpg",
                            LastName = "Neutron",
                            Password = "$2a$11$pKZ8ulrzZLk7MlM4agwElepWp4fQaBDyD3hKJ4mcOM3w63ZQIyXa6",
                            Role = "user",
                            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImppbW15X25ldXRyb24iLCJqdGkiOiI0YjVjOGQ3Yy01YTVhLTRhMDQtOGRlYS1lY2YwZTg1MDQ1Y2QiLCJleHAiOjE2MTAwMTc2MDUsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.Nh0BN86uCvxQgBbyX245iQa1fuJspXkbKWZ89H1pLik",
                            Username = "jimmy_neutron"
                        },
                        new
                        {
                            Id = 6,
                            Email = "timmy_turner@local.loc",
                            FirstName = "Timmy",
                            Image = "https://localhost:5001/resources/images/timmy.png",
                            LastName = "Turner",
                            Password = "$2a$11$qoDJzk7Y33j9YO32EuUsUeZjBcdWQtf3qrha8RmFpV/fBRFaltQtu",
                            Role = "user",
                            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRpbW15X3R1cm5lciIsImp0aSI6IjgxYmVlNzIwLTVhOGMtNDNlNC1iMDg5LWI0NWZiZjc2N2U2OCIsImV4cCI6MTYxMDAxNzYwNSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMSIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEifQ.zdwU5bbz527OMLR_1A8RBIUG-IQrMosvxjfbwI740t8",
                            Username = "timmy_turner"
                        },
                        new
                        {
                            Id = 7,
                            Email = "iron_man@local.loc",
                            FirstName = "Iron",
                            Image = "https://localhost:5001/resources/images/ironman.jpg",
                            LastName = "Man",
                            Password = "$2a$11$H3FX8Jvyg1EJBhf0lybBi.k.q.WTUV0En9PXTebfyI2ezECD/s9pu",
                            Role = "user",
                            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Imlyb25tYW4iLCJqdGkiOiI4Zjk0MGNkMi05OWU2LTQyOGItYTQ1Yy1jMDIyYzQ1NmQ4ZmYiLCJleHAiOjE2MTAwMTc2MDUsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.WIrheMS0FJTL0G8v_wxW9TbkaU2R-yZN0vhyRj6w5bY",
                            Username = "ironman"
                        });
                });

            modelBuilder.Entity("MyApiWeb.Models.Videos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("src");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Src = "https://localhost:5001/resources/videos/v1.mp4",
                            Type = "video/mp4"
                        },
                        new
                        {
                            Id = 2,
                            Src = "https://localhost:5001/resources/videos/v2.mp4",
                            Type = "video/mp4"
                        },
                        new
                        {
                            Id = 3,
                            Src = "https://localhost:5001/resources/videos/v3.mp4",
                            Type = "video/mp4"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
