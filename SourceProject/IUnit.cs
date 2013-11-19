using System;
namespace SourceProject
{
    interface IUnit
    {
        bool attack(int x, int y);
        void getBox();
        void getDefensive();
        void getLifePoints();
        void getOffensive();
        int getPoint();
        bool hasMoves();
        bool isAlive();
        bool move(int x, int y);
        bool setLifePoints(int value);
    }
}
