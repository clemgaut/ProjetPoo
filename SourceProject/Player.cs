﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using SourceProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player : IPlayer
{
	private string _name;

	private Nation _nation;

	private int _points;

    public Player()
    {
        _points = 0;
    }

	public virtual void setNation(Nation nation)
	{
		_nation = nation;
	}

	public virtual string getName()
	{
		return _name;
	}

	public virtual void refresh()
	{
		throw new System.NotImplementedException();
	}

	public virtual List<Unit> getSelectableUnits()
	{
        List<Unit> l = new List<Unit>();

        foreach(Unit u in _nation.getUnits())
        {
            if (u.hasMoves())
                l.Add(u);
        }
        return l;
	}

    /*
     * Return the units that are on the rectangle with line and column in parameters
     */
    public virtual List<Unit> getUnits(int line, int column)
    {
        List<Unit> l = new List<Unit>();

        foreach (Unit u in _nation.getUnits())
        {
            if (u.getLine() == line && u.getColumn() == column)
                l.Add(u);
        }
        return l;
    }

	public virtual Nation getNation()
	{
		return _nation;
	}
}

