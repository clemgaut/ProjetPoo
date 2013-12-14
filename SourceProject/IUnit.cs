using System;
namespace SourceProject
{
    interface IUnit
    {
        bool attack(int line, int column);
        int getLine();
        int getColumn();
        void getDefensive();
        void getLifePoints();
        void getOffensive();
        int getPoint();
        bool hasMoves();
        bool isAlive();
        bool move(int line, int column);
        bool setLifePoints(int value);
    }
}
