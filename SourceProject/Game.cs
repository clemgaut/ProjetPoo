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

public class Game : IGame
{
	protected Map _map;

	protected Player _player1;

	protected Player _player2;

	public virtual void setMap(Map map)
	{
		throw new System.NotImplementedException();
	}

    public virtual Map getMap()
    {
        return _map;
    }

	public virtual void setMaxSteps(int max)
	{
		throw new System.NotImplementedException();
	}

	public virtual Player getActivePlayer()
	{
		throw new System.NotImplementedException();
	}

	public Game()
	{
	}

	public virtual void checkWinner()
	{
		throw new System.NotImplementedException();
	}

	public virtual void endOfPlay()
	{
		throw new System.NotImplementedException();
	}

	public virtual bool fight()
	{
		throw new System.NotImplementedException();
	}


	public virtual bool move()
	{
		throw new System.NotImplementedException();
	}

	public virtual void onPropertyChanged()
	{
		throw new System.NotImplementedException();
	}

	public virtual void start()
	{
		throw new System.NotImplementedException();
	}

	public virtual Unit getBestDefensiveUnit(int x, int y)
	{
		throw new System.NotImplementedException();
	}

	public virtual bool checkEndfOfGame()
	{
		throw new System.NotImplementedException();
	}

	public virtual void nextStep()
	{
		throw new System.NotImplementedException();
	}


	public virtual Player getWinner()
	{
		throw new System.NotImplementedException();
	}

}

