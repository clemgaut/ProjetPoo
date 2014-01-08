using System;
namespace SourceProject {
    /// <summary>
    /// Interface for the unit
    /// </summary>
    interface IUnit {
        void setLifePoints(int value);
        int getLine();
        int getColumn();
        double getDefensive();
        int getLifePoints();
        double getOffensive();
        int getPoint(Map m);
        bool move(int line, int column, Map m);
        bool canMove(int line, int column, Map m);
        bool hasMoves();
        void initMovePoints();
        bool attack(Unit defUnit);
        bool isAlive();
    }
}
