using System;
namespace SourceProject {
    interface IGameDirector {
        void buildGame(EGameType gameType, ENation nation1, ENation nation2);
        void endOfStep();
        Player getActivePlayer();
        Unit[] getSelectableUnits();
        void initStep();
        void selectAdjacentBox(int x, int y);
        void SelectUnit(int i);
        void stopGame();
    }
}
