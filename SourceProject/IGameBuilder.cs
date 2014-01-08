using System;
namespace SourceProject {
    /// <summary>
    /// Interface for the game builder
    /// </summary>
    interface IGameBuilder {
        public void createPlayers(ENation nation1, ENation nation2);
        public virtual IGame getGame();
        public virtual IPlayer getPlayer1();
        public virtual IPlayer getPlayer2();
    }
}
