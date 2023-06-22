using Role_Playing_Game.Classes;
try
{
    Game game = new Game();
    game.StartGame();
}catch (Exception e)
{
    Console.WriteLine(e.Message);
}