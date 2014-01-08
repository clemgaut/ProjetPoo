using SourceProject;
using System;

/// <summary>
/// The unit class
/// </summary>
/// 
[Serializable]
public abstract class Unit : IUnit {

    protected int _lifePoints;
    protected double _movePoints;

    protected double _defensive;
    protected double _offensive;

    protected int _line;
    protected int _column;

    private static Random random = new Random();

    /// <summary>
    /// Constructor
    /// </summary>
    public Unit() {
        _lifePoints = 5;
        _movePoints = 1;
        _defensive = 1;
        _offensive = 2;
        _line = -1;
        _column = -1;
    }

    /// <summary>
    /// Set the unit life point to value
    /// </summary>
    /// <param name="value">The new value of unit's lifepoints</param>
    public void setLifePoints(int value) {
        _lifePoints = value;
    }

    /// <summary>
    /// Get the line where the unit is.
    /// </summary>
    /// <returns>The line where the unit is</returns>
    public int getLine() {
        return _line;
    }

    /// <summary>
    /// Get the column where the unit is.
    /// </summary>
    /// <returns>The column where the unit is</returns>
    public int getColumn() {
        return _column;
    }

    /// <summary>
    /// Get the defensive points of the unit. Depends on his life points
    /// </summary>
    /// <returns>The defensive points of the unit></returns>
    public double getDefensive() {
        return _defensive * (_lifePoints/5.0);
    }

    /// <summary>
    /// Get the life points of the unit
    /// </summary>
    /// <returns>The life points of the unit</returns>
    public int getLifePoints() {
        return _lifePoints;
    }

    /// <summary>
    /// Get the offensive points of the unit. Depends on his life points
    /// </summary>
    /// <returns>The offensive points of the unit></returns>
    public double getOffensive() {
        return _offensive * (_lifePoints / 5.0);
    }

    /// <summary>
    /// Get the points won by the unit
    /// </summary>
    /// <param name="m">The map that the player is on</param>
    /// <returns>The points</returns>
    public abstract int getPoint(Map m);

    /// <summary>
    /// Move the unit to the tile if possible
    /// </summary>
    /// <param name="line">The tile's line the unit want to move</param>
    /// <param name="column">The tile's column the unit want to move</param>
    /// <param name="m">The map on which the unit is placed</param>
    /// <returns>True if the unit moved to the tile, false otherwise</returns>
    public abstract bool move(int line, int column, Map m);

    /// <summary>
    /// Return wether the unit can move to the tile or not
    /// </summary>
    /// <param name="line">The tile's line the unit want to move</param>
    /// <param name="column">The tile's column the unit want to move</param>
    /// <param name="m">The map on which the unit is placed</param>
    /// <returns>True if the unit can move to the tile, false otherwise</returns>
    public abstract bool canMove(int line, int column, Map m);

    /// <summary>
    /// Chech if the unit has move points
    /// </summary>
    /// <returns>False if the unit has no move point, true otherwise</returns>
    public bool hasMoves() {
        return _movePoints > 0;
    }

    /// <summary>
    /// Initialize the move points (set to 1).
    /// </summary>
    public void initMovePoints() {
        _movePoints = 1;
    }

    /// <summary>
    /// Attack an unit
    /// </summary>
    /// <param name="defUnit">The unit to attack (defensive unit)</param>
    /// <returns>True if the unit kill the defensive unit, false if the unit die</returns>
    public bool attack(Unit defUnit) {

        double pAttWin;
        int result;

        int nbCombat = random.Next(3, Math.Max(_lifePoints, defUnit.getLifePoints()) + 2);

        for(int i = 0; i < nbCombat; i++) {

            pAttWin = (1 - (0.5 * defUnit.getDefensive() / getOffensive())) * 100;

            if(pAttWin == 100) {
                defUnit.setLifePoints(0);
                return true;
            }

            result = random.Next(0, 100);

            if(result <= pAttWin)
                defUnit.setLifePoints(defUnit.getLifePoints() - 1);
            else
                _lifePoints--;

            if(!defUnit.isAlive())
                return true;

            if(!isAlive())
                return false;
        }

        return false;
    }

    /// <summary>
    /// Check if the unit is alive
    /// </summary>
    /// <returns>True if the unit has life points, false otherwise</returns>
    public bool isAlive() {
        return _lifePoints > 0;
    }

    /// <summary>
    /// Set the unit to an null position (outside the map) : -1:-1
    /// </summary>
    internal void nullPosition() {
        _column = -1;
        _line = -1;
    }
}

