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

/// <summary>
/// The game (map, players and steps)
/// </summary>
public class Game : IGame {
    protected Map _map;

    protected Player _player1;

    protected Player _player2;

    protected Player _activePlayer;

    protected int _steps;

    /// <summary>
    /// Constructor
    /// </summary>
    public Game() {
    }

    /// <summary>
    /// Set the game's map
    /// </summary>
    /// <param name="map">The map that will be used for the game</param>
    public virtual void setMap(Map map) {
        _map = map;
    }

    /// <summary>
    /// Set the first player
    /// </summary>
    /// <param name="p">The first player</param>
    public void setPlayer1(Player p) {
        _player1 = p;
    }

    /// <summary>
    /// Set the second player
    /// </summary>
    /// <param name="p">The second player</param>
    public void setPlayer2(Player p) {
        _player2 = p;
    }

    /// <summary>
    /// Get the first player
    /// </summary>
    /// <returns>The first player</returns>
    public virtual Player getPlayer1() {
        return _player1;
    }

    /// <summary>
    /// Get the second player
    /// </summary>
    /// <returns>The second player</returns>
    public virtual Player getPlayer2() {
        return _player2;
    }

    /// <summary>
    /// Get the map
    /// </summary>
    /// <returns>The game's map</returns>
    public virtual Map getMap() {
        return _map;
    }

    /// <summary>
    /// Set the number of maximum game's steps
    /// </summary>
    /// <param name="max">The number of maximum game's steps</param>
    public virtual void setMaxSteps(int max) {
        _steps = max;
    }

    /// <summary>
    /// Get the active player
    /// </summary>
    /// <returns>The active player (null if none)</returns>
    public virtual Player getActivePlayer() {
        return _activePlayer;
    }

    /// <summary>
    /// Get the unactive player
    /// </summary>
    /// <returns>The unactive player (null if none is active)</returns>
    public virtual Player getUnactivePlayer() {
        if(_activePlayer == _player1)
            return _player2;

        if(_activePlayer == _player2)
            return _player1;

        return null;
    }

    /// <summary>
    /// Return a list with the int position of the opponent units (row*width+col)
    /// </summary>
    /// <returns>A list with the int position of the opponent units (row*width+col)</returns>
    public virtual List<int> getOpponentUnitsPositions() {
        List<int> l = new List<int>();

        foreach (Unit u in getUnactivePlayer().getNation().getUnits()) {
            l.Add(u.getLine() * _map.Width + u.getColumn());
        }
        return l;
    }

    /// <summary>
    /// Check if the first player is active
    /// </summary>
    /// <returns>True if the first player is active, false otherwise</returns>
    public virtual bool isPlayer1Active() {
        return _activePlayer == _player1;
    }

    /// <summary>
    /// Start the game (set the active player to player 1).
    /// </summary>
    public virtual void start() {
        _activePlayer = _player1;
    }

    /// <summary>
    /// Get the best defensive unit on the tile wanted
    /// </summary>
    /// <param name="line">The tile's line</param>
    /// <param name="column">The tile's column</param>
    /// <returns>The best defensive unit, null if none</returns>
    public virtual Unit getBestDefensiveUnit(int line, int column) {
        List<Unit> unitsUnactivePlayer = getUnactivePlayer().getUnits(line, column);
        Unit bestDefUnit = null;

        foreach(Unit u in unitsUnactivePlayer)
            if(bestDefUnit == null || bestDefUnit.getDefensive() < u.getDefensive())
                bestDefUnit = u;

        return bestDefUnit;
    }

    /// <summary>
    /// Check wether the game is over or not (no more steps or no more unit for one player)
    /// </summary>
    /// <returns>True if the game is over, false otherwise.</returns>
    public virtual bool checkEndfOfGame() {
        return (_steps == 0 || _player1.getNbUnits() == 0 || _player2.getNbUnits()==0);
    }

    /// <summary>
    /// Go to the next game's step : change the current player, update points and update step number
    /// </summary>
    public virtual void nextStep() {
        _activePlayer.getNation().initMovePoints();
        if(_steps > 0 && _activePlayer == _player2)
            _steps--;

        if (_activePlayer != null)
            _activePlayer.updatePoints(_map);

        if(_activePlayer == _player1)
            _activePlayer = _player2;
        else
            _activePlayer = _player1;
    }

    /// <summary>
    /// Get the number of remaining steps
    /// </summary>
    /// <returns>The number of remaining steps</returns>
    public virtual int getSteps() {
        return _steps;
    }

    /// <summary>
    /// Return the winner (player with most points)
    /// </summary>
    /// <returns>The winner</returns>
    public virtual Player getWinner() {
        if (_player1.getPoints() < _player2.getPoints())
            return _player2;
        if (_player1.getPoints() > _player2.getPoints())
            return _player1;

        return null;
    }
}

