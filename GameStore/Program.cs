using GameStore.Dtos;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games =
[
new(
     1,
    "The Legend of Zelda: Breath of the Wild",
    "Action-adventure",
    59.99m,
    new DateOnly(2017, 3, 3)
),
new(
    2,
    "The Witcher 3: Wild Hunt",
    "Action RPG",
    39.99m,
    new DateOnly(2015, 5, 19)
),
new(
    3,
    "Stardew Valley",
    "Simulation RPG",
    14.99m,
    new DateOnly(2016, 2, 26)
)
];

app.MapGet("/game", () => games);

// game/{id} endpoint

app.MapGet("game/{id}", (int id) => games.Find(games => games.Id == id));

app.MapGet("/", () => "Welcome to the Game Store!");

app.Run();
