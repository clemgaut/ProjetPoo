﻿using System;
namespace SourceProject
{
    interface IGame
    {
        bool checkEndfOfGame();
        void checkWinner();
        void endOfPlay();
        bool fight();
        Player getActivePlayer();
        Unit getBestDefensiveUnit(int x, int y);
        Player getWinner();
        bool move();
        void nextStep();
        void onPropertyChanged();
        void setMap(Map map);
        Map getMap();
        void setMaxSteps(int max);
        void start();
    }
}
