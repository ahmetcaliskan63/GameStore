# GameStore API

A simple RESTful API for managing a game store inventory built with ASP.NET Core.

## Features

- CRUD operations for game management
- RESTful endpoints for game operations
- In-memory data storage
- JSON response format

## API Endpoints

### Get All Games
- **GET** `/games`
- Returns a list of all games in the store

### Get Game by ID
- **GET** `/games/{id}`
- Returns a specific game by its ID
- Returns 404 if game is not found

### Create New Game
- **POST** `/games`
- Creates a new game in the store
- Required fields: Name, Genre, Price, ReleaseDate
- Returns the created game with its ID

### Update Game
- **PUT** `/games/{id}`
- Updates an existing game
- Required fields: Name, Genre, Price, ReleaseDate
- Returns 204 No Content on success
- Returns 404 if game is not found

### Delete Game
- **DELETE** `/games/{id}`
- Removes a game from the store
- Returns 204 No Content on success
- Returns 404 if game is not found

## Data Model

### Game Properties
- Id (int)
- Name (string)
- Genre (string)
- Price (decimal)
- ReleaseDate (DateOnly)

## Technologies Used

- ASP.NET Core
- C#
- Minimal API architecture

## Getting Started

1. Clone the repository
2. Open the solution in Visual Studio or your preferred IDE
3. Build and run the project
4. The API will be available at `http://localhost:5000` or `https://localhost:5001`

## Testing the API

You can use the included `Game.http` file to test the API endpoints using tools like Visual Studio Code's REST Client extension or Postman.

## License

This project is licensed under the MIT License.
