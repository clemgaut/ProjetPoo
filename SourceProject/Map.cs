﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
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

	public virtual IEnumerable<IEnumerable<int>> getInitCoordonates()
	{
		throw new System.NotImplementedException();
	}

	public Map()
	{
	}

}

