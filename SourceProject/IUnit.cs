using System;
namespace SourceProject {
    /// <summary>
    /// Interface for the unit
    /// </summary>
    interface IUnit {
        bool attack(Unit defUnit);
        int getLine();
        int getColumn();
        double getDefensive();
        int getLifePoints();
        double getOffensive();
        int getPoint(Map m);
        bool hasMoves();
        bool isAlive();
        bool move(int line, int column, Map m);
        void setLifePoints(int value);
    }
}
