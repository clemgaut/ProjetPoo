using System;
namespace SourceProject {
    /// <summary>
    /// Interface for the game builder
    /// </summary>
    interface IGameBuilder {
        void createPlayers(ENation nation1, ENation nation2);
        Game getGame();
        Player getPlayer1();
        Player getPlayer2();
    }
}
