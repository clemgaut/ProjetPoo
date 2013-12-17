using System;
namespace SourceProject {
    interface IUnit {
        bool attack(Unit defUnit);
        int getLine();
        int getColumn();
        double getDefensive();
        int getLifePoints();
        double getOffensive();
        int getPoint();
        bool hasMoves();
        bool isAlive();
        bool move(int line, int column);
        void setLifePoints(int value);
    }
}
