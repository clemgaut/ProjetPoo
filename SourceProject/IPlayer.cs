using System;
using System.Collections.Generic;
namespace SourceProject {
    /// <summary>
    /// Interface for the player
    /// </summary>
    interface IPlayer {
        public virtual void setName(string name);
        public virtual void setNation(INation nation);
        public virtual string getName();
        public virtual INation getNation();
        public virtual int getPoints();
        public virtual void updatePoints(IMap m);
    }
}
