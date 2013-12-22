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

public class Game : IGame {
    protected Map _map;

    protected Player _player1;

    protected Player _player2;

    protected Player _activePlayer;

    protected int _steps;

    public Game() {
    }

    public virtual void setMap(Map map) {
        _map = map;
    }

    public void setPlayer1(Player p) {
        _player1 = p;
    }

    public void setPlayer2(Player p) {
        _player2 = p;
    }

    public virtual Player getPlayer1() {
        return _player1;
    }

    public virtual Player getPlayer2() {
        return _player2;
    }

    public virtual Map getMap() {
        return _map;
    }

    public virtual void setMaxSteps(int max) {
        _steps = max;
    }

    public virtual Player getActivePlayer() {
        return _activePlayer;
    }

    public virtual Player getUnactivePlayer() {
        if(_activePlayer == _player1)
            return _player2;

        if(_activePlayer == _player2)
            return _player1;

        return null;
    }

    public virtual bool isPlayer1Active() {
        return _activePlayer == _player1;
    }

    public virtual void checkWinner() {
        throw new System.NotImplementedException();
    }

    public virtual void endOfPlay() {
        throw new System.NotImplementedException();
    }

    public virtual bool fight() {
        throw new System.NotImplementedException();
    }


    public virtual bool move() {
        throw new System.NotImplementedException();
    }

    public virtual void onPropertyChanged() {
        throw new System.NotImplementedException();
    }

    public virtual void start() {
        _activePlayer = _player1;
    }

    public virtual Unit getBestDefensiveUnit(int line, int column) {
        List<Unit> unitsUnactivePlayer = getUnactivePlayer().getUnits(line, column);
        Unit bestDefUnit = null;

        foreach(Unit u in unitsUnactivePlayer)
            if(bestDefUnit == null || bestDefUnit.getDefensive() < u.getDefensive())
                bestDefUnit = u;

        return bestDefUnit;
    }

    /**
     * Return true if the game is over
     */
    public virtual bool checkEndfOfGame() {
        return (_steps == 0 || _player1.getNbUnits() == 0 || _player2.getNbUnits()==0);
    }

    /**
     * Change the current player, update points and update step number
     */
    public virtual void nextStep() {
        if(_steps > 0 && _activePlayer == _player2)
            _steps--;

        if (_activePlayer != null)
            _activePlayer.updatePoints(_map);

        if(_activePlayer == _player1)
            _activePlayer = _player2;
        else
            _activePlayer = _player1;
    }

    public virtual int getSteps() {
        return _steps;
    }

    public virtual Player getWinner() {
        if (_player1.getPoints() < _player2.getPoints())
            return _player2;
        if (_player1.getPoints() > _player2.getPoints())
            return _player1;

        return null;
    }
}

