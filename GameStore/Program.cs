using GameStore.Dtos;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGameById";

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

app.MapGet("/games", () => games);

// game/{id} endpoint

app.MapGet("games/{id}", (int id) =>
{
    GameDto? game = games.Find(games => games.Id == id);

    return game is null ? Results.NotFound() : Results.Ok(game);
})
.WithName(GetGameEndpointName);

// POST /game endpoint
app.MapPost("games", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});


//PUT /game/{id} endpoint

app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var index = games.FindIndex(g => g.Id == id);

    if (index == -1)
    {
        return Results.NotFound();
    }

    games[index] = new GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );
    return Results.NoContent();
});

// DELETE /game/{id} endpoint

app.MapDelete("games/{id}", (int id) =>
{
    var index = games.FindIndex(g => g.Id == id);
    games.RemoveAt(index);


    return Results.NoContent();
});



app.Run();
