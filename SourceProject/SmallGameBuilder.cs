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

public class SmallGameBuilder : GameBuilder
{
    public SmallGameBuilder(ENation nation1, ENation nation2)
	{
        Map map = new SmallMap();
        _game.setMap(map);
        _game.setMaxSteps(20);
        _unitNumber = 6;
        createPlayers(nation1, nation2);
	}

}

