using System;
using System.Collections.Generic;
namespace SourceProject {
    /// <summary>
    /// Interface for the game
    /// </summary>
    interface IGame {
        public virtual void setMap(IMap map);
        public void setPlayer1(IPlayer p);
        public void setPlayer2(IPlayer p);
        public virtual IPlayer getPlayer1();
        public virtual IPlayer getPlayer2();
        public virtual IMap getMap();
        public virtual void setMaxSteps(int max);
        public virtual IPlayer getActivePlayer();
        public virtual IPlayer getUnactivePlayer();
        public virtual List<int> getOpponentUnitsPositions();
        public virtual bool isPlayer1Active();
        public virtual void start();
        public virtual IUnit getBestDefensiveUnit(int line, int column);
        public virtual bool checkEndfOfGame();
        public virtual void nextStep();
        public virtual int getSteps();
        public virtual IPlayer getWinner();
    }
}
