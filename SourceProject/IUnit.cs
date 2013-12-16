using System;
namespace SourceProject {
    interface IUnit {
        bool attack(int line, int column);
        int getLine();
        int getColumn();
        int getDefensive();
        int getLifePoints();
        int getOffensive();
        int getPoint();
        bool hasMoves();
        bool isAlive();
        bool move(int line, int column);
        void setLifePoints(int value);
    }
}
