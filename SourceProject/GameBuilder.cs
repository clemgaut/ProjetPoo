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
/// The game builder
/// </summary>
public abstract class GameBuilder : IGameBuilder {
    protected Game _game;
    protected Player _player1;
    protected Player _player2;
    protected int _unitNumber;

    /// <summary>
    /// Constructor
    /// </summary>
    public GameBuilder() {
        _game = new Game();
        _player1 = new Player();
        _player2 = new Player();
    }

    /// <summary>
    /// Create the players and set them on the map
    /// </summary>
    /// <param name="nation1">The nation of the first player</param>
    /// <param name="nation2">The nation of the second player</param>
    public void createPlayers(ENation nation1, ENation nation2) {
        Nation nationPlayer1 = new Nation(nation1, _unitNumber);
        Nation nationPlayer2 = new Nation(nation2, _unitNumber);

        bool nation1Place = false, nation2Place = false;

        while (!nation1Place || !nation2Place) {
            List<List<int>> initCoord = (List<List<int>>) _game.getMap().getInitCoordonates();

            nation1Place = nationPlayer1.setInitBox(initCoord[0][0], initCoord[0][1], _game.getMap());
            nation2Place = nationPlayer2.setInitBox(initCoord[1][0], initCoord[1][1], _game.getMap());
        }

        _player1.setNation(nationPlayer1);
        _player2.setNation(nationPlayer2);

        _game.setPlayer1(_player1);
        _game.setPlayer2(_player2);
    }

    /// <summary>
    /// Get the game
    /// </summary>
    /// <returns>The game</returns>
    public virtual Game getGame() {
        return _game;
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

}

