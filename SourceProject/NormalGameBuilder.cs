﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NormalGameBuilder : GameBuilder {
    /// <summary>
    /// Constructor : build the game (map, players)
    /// </summary>
    /// <param name="nation1">The nation of the first player</param>
    /// <param name="nation2">The nation of the second player</param>
    public NormalGameBuilder(ENation nation1, ENation nation2) {
        Map map = new NormalMap();
        _game.setMap(map);
        _game.setMaxSteps(30);
        _unitNumber = 8;
        createPlayers(nation1, nation2);
    }

}

