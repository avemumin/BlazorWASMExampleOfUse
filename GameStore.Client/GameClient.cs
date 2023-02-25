using GameStore.Client.Models;

namespace GameStore.Client;

public static class GameClient
{
    private static readonly List<Game> games = new()
    {
        new Game(){ Id =1, Name ="Street Fighter II" , Genre = "Fighting" , Price= 19.99M, ReleaseDate = new DateTime(1991,2,1)},
        new Game(){ Id =2, Name ="Final Fantasy VII" , Genre = "Roleplayng" , Price= 59.99M, ReleaseDate = new DateTime(1997,09,27)},
        new Game(){ Id =3, Name ="Fifa 23" ,            Genre = "Sports" , Price= 39.99M, ReleaseDate = new DateTime(2002,08,11)}
    };

    public static Game[] GetGames()
    {
        return games.ToArray();
    }

    public static void AddGame(Game game)
    {
        game.Id = games.Max(x => x.Id) + 1;
        games.Add(game);
    }

    public static Game GetGame(int id)
    {
        var selectedGame = games.Find(x => x.Id == id) ?? throw new Exception("Could not find game!");
        return selectedGame;
    }
    public static void UpdateGame(Game updatedGame)
    {
        var gameToEdit = GetGame(updatedGame.Id);

        gameToEdit.Id = updatedGame.Id;
        gameToEdit.Name = updatedGame.Name;
        gameToEdit.Genre = updatedGame.Genre;
        gameToEdit.Price = updatedGame.Price;
        gameToEdit.ReleaseDate = updatedGame.ReleaseDate;

    }

    public static void DeleteGame(int id)
    {
        var gameToRemove = GetGame(id);
        games.Remove(gameToRemove);

    }
}
