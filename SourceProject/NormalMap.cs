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
/// The map of a normal game
/// </summary>
/// 
[Serializable]
public class NormalMap : Map {
    /// <summary>
    /// Constructor : build a 15x15 map
    /// </summary>
    public NormalMap() {
        Width = 15;
        Height = 15;
        generateMap();
    }

}

