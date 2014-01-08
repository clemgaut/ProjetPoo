using System;
using System.Collections.Generic;
namespace SourceProject {
    /// <summary>
    /// Interface for the game
    /// </summary>
    interface IGame {
        void setMap(Map map);
        void setPlayer1(Player p);
        void setPlayer2(Player p);
        Player getPlayer1();
        Player getPlayer2();
        Map getMap();
        void setMaxSteps(int max);
        Player getActivePlayer();
        Player getUnactivePlayer();
        List<int> getOpponentUnitsPositions();
        bool isPlayer1Active();
        void start();
        Unit getBestDefensiveUnit(int line, int column);
        bool checkEndfOfGame();
        void nextStep();
        int getSteps();
        Player getWinner();
    }
}
