using System;
using System.Collections.Generic;
namespace SourceProject {
    /// <summary>
    /// Interface for the player
    /// </summary>
    interface IPlayer {
        string getName();
        Nation getNation();
        void setNation(Nation nation);
    }
}
