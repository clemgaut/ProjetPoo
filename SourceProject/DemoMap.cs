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

/// <summary>
/// The map for demo game
/// </summary>
public class DemoMap : Map {
    /// <summary>
    /// Constructor : build a 5x5 map
    /// </summary>
    public DemoMap() {
        Width = 5;
        Height = 5;
        generateMap();
    }

}

