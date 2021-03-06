﻿
using SourceProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// A nation
/// </summary>
/// 
[Serializable]
public class Nation : INation {

    
    private List<Unit> _units;
    [NonSerialized]
    private IUnitFactory<Unit> _unitFactory;
    public ENation nationType {
        set;
        get;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="nation">The nation type</param>
    /// <param name="unitNumber">The number of unit (depends on the game's type)</param>
    public Nation(ENation nation, int unitNumber) {
        nationType = nation;

        switch(nationType) {
            case ENation.GAUL:
                _unitFactory = new UnitFactory<GaulUnit>();
                break;

            case ENation.NAIN:
                _unitFactory = new UnitFactory<NainUnit>();
                break;

            case ENation.VIKING:
                _unitFactory = new UnitFactory<VikingUnit>();
                break;
        }

        _units = _unitFactory.getUnits(unitNumber);

    }

    /// <summary>
    /// Get the number of units
    /// </summary>
    /// <returns>The number of units.</returns>
    public virtual int getUnitsNumber() {
        return _units.Count();
    }

    /// <summary>
    /// Get the units
    /// </summary>
    /// <returns>The units.</returns>
    public virtual List<Unit> getUnits() {
        return (_units.Count() == 0) ? new List<Unit>() : _units;
    }

    /// <summary>
    /// Delete dead units
    /// </summary>
    public virtual void deleteDeadUnits() {
        _units.RemoveAll(u => !u.isAlive());
    }

    /// <summary>
    /// Get the unit number i
    /// </summary>
    /// <param name="i">The unit's number (index in the units list)</param>
    /// <returns>The unit.</returns>
    public virtual Unit getUnit(int i) {
        return _units.ElementAt(i);
    }

    /// <summary>
    /// Return the units placed on the tile with the given coordonates
    /// </summary>
    /// <param name="line">The tile's line</param>
    /// <param name="column">The tile's column</param>
    /// <returns>A list of unit (empty if none).</returns>
    public virtual List<Unit> getUnits(int line, int column) {
        List<Unit> l = new List<Unit>();

        foreach(Unit u in _units) {
            if(u.getLine() == line && u.getColumn() == column)
                l.Add(u);
        }
        return l;
    }

    /// <summary>
    /// Move nation's units to the init box if possible. Return false if not possible to move.
    /// </summary>
    /// <param name="line">The line of the init box</param>
    /// <param name="column">The column of the init box</param>
    /// <param name="m">The map the nation's unit will be</param>
    /// <returns>False if not possible to move, true otherwise</returns>
    public virtual bool setInitBox(int line, int column, Map m) {
        bool move = true;
        foreach(Unit u in _units) {
            move = move && u.move(line, column, m);
            u.initMovePoints();
        }
        if (!move) {
            moveToNullPosition();
        }
        return move;
    }

    /// <summary>
    /// Move all units outside the map
    /// </summary>
    public void moveToNullPosition() {
        foreach (Unit u in _units) {
            u.nullPosition();
        }
    }

    /// <summary>
    /// Initialize the move points of each unit of the nation.
    /// </summary>
    internal void initMovePoints() {
        foreach (Unit u in _units)
            u.initMovePoints();
    }
}

