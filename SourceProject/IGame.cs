using System;
namespace SourceProject {
    /// <summary>
    /// Interface for the game
    /// </summary>
    interface IGame {
        bool checkEndfOfGame();
        Player getActivePlayer();
        Unit getBestDefensiveUnit(int x, int y);
        Player getWinner();
        void nextStep();
        void setMap(Map map);
        Map getMap();
        void setMaxSteps(int max);
        void start();
    }
}
