using SourceProject;
using System;

public class Unit : IUnit {

    protected int _lifePoints;
    protected double _movePoints;

    protected double _defensive;
    protected double _offensive;

    protected int _line;
    protected int _column;

    public Unit() {
        _lifePoints = 5;
        _movePoints = 1;
        _defensive = 1;
        _offensive = 2;
    }

    /**
     * Set the unit life point to value
     * @param value Number of life point
     */
    public virtual void setLifePoints(int value) {
        _lifePoints = value;
    }

    public virtual int getLine() {
        return _line;
    }

    public virtual int getColumn() {
        return _column;
    }

    public virtual double getDefensive() {
        return _defensive * (_lifePoints/5);
    }

    public virtual int getLifePoints() {
        return _lifePoints;
    }

    public virtual double getOffensive() {
        return _offensive * (_lifePoints / 5);
    }

    public abstract virtual int getPoint(Map m);

    public virtual bool move(int line, int column) {
        _line = line;
        _column = column;

        return true;
    }

    public virtual bool hasMoves() {
        return _movePoints > 0;
    }

    /**
     * Attack an unit
     * @param defUnit the unit to attack
     * @return true if the unit kill the defensive unit, false if the unit die
     */
    public virtual bool attack(Unit defUnit) {

        double pAttWin;
        int result;

        Random random = new Random();
        int nbCombat = random.Next(3, Math.Max(_lifePoints, defUnit.getLifePoints()) + 2);

        for(int i = 0; i < nbCombat; i++) {

            pAttWin = (1 - (0.5 * defUnit.getDefensive() / getOffensive())) * 100;

            if(pAttWin == 100) {
                defUnit.setLifePoints(0);
                return true;
            }

            result = random.Next(0, 100);

            if(result <= pAttWin)
                defUnit.setLifePoints(getLifePoints() - 1);
            else
                _lifePoints--;

            if(!defUnit.isAlive())
                return true;

            if(!isAlive())
                return false;
        }

        return false;
    }

    public virtual bool isAlive() {
        return _lifePoints > 0;
    }
}

