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

public abstract class Map : IMap
{
	private BoxFactory fabriqueCase;

	protected IEnumerable<Box> _map;

	public virtual void genererCarte()
	{
		throw new System.NotImplementedException();
	}

	public virtual void refreshMap()
	{
		throw new System.NotImplementedException();
	}

	public virtual void showMap()
	{
		throw new System.NotImplementedException();
	}

	public virtual void setBox(Box box, int x, int y)
	{
		throw new System.NotImplementedException();
	}

	public virtual void addNation(Nation nation)
	{
		throw new System.NotImplementedException();
	}

	public virtual IEnumerable<IEnumerable<int> > getInitCoordonates()
	{
		throw new System.NotImplementedException();
	}

	public Map()
	{
	}
}

