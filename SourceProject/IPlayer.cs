using System;
using System.Collections.Generic;
namespace SourceProject {
    /// <summary>
    /// Interface for the player
    /// </summary>
    interface IPlayer {
        void setName(string name);
        void setNation(Nation nation);
        string getName();
        Nation getNation();
        int getPoints();
        void updatePoints(Map m);
    }
}
