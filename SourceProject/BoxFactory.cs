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
/// The factory for boxes
/// </summary>
public class BoxFactory : IBoxFactory {

    protected Box _desertBox;
    protected Box _forestBox;
    protected Box _lowlandBox;
    protected Box _mountainBox;
    protected Box _seaBox;

    /// <summary>
    /// Return the box wanted or null if not found
    /// </summary>
    /// <param name="boxType">The type of box wanted</param>
    /// <returns>The box wanted or null if not found</returns>
    public virtual Box getBox(EBoxType boxType) {
        Box box;
        switch(boxType) {
            case EBoxType.DESERT:
                box = _desertBox;
                break;

            case EBoxType.FOREST:
                box = _forestBox;
                break;

            case EBoxType.LOWLAND:
                box = _lowlandBox;
                break;

            case EBoxType.MOUNTAIN:
                box = _mountainBox;
                break;

            case EBoxType.SEA:
                box = _seaBox;
                break;

            default:
                box = null;
                break;
        }
        return box;
    }

    /// <summary>
    /// Constructor : build all boxes
    /// </summary>
    public BoxFactory() {
        _desertBox = new DesertBox();
        _forestBox = new ForestBox();
        _lowlandBox = new LowlandBox();
        _mountainBox = new MountainBox();
        _seaBox = new SeaBox();
    }

}

