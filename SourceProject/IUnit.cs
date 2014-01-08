using System;
namespace SourceProject {
    /// <summary>
    /// Interface for the unit
    /// </summary>
    interface IUnit {
        public void setLifePoints(int value);
        public int getLine();
        public int getColumn();
        public double getDefensive();
        public int getLifePoints();
        public double getOffensive();
        public abstract int getPoint(IMap m);
        public abstract bool move(int line, int column, IMap m);
        public abstract bool canMove(int line, int column, IMap m);
        public bool hasMoves();
        public void initMovePoints();
        public bool attack(IUnit defUnit);
        public bool isAlive();
    }
}
