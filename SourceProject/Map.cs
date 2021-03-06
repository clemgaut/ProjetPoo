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
/// The map class
/// </summary>
/// 
[Serializable]
public abstract class Map : IMap {

    [NonSerialized]
    protected BoxFactory _boxFactory;
    [NonSerialized]
    protected Wrapper.WrapperAlgo _wrapperAlgo;
    protected Box[,] _map;

    public int Width {
        get;
        set;
    }

    public int Height {
        get;
        set;
    }

    /// <summary>
    /// Generate the map (call the wrapper)
    /// </summary>
    public virtual void generateMap() {
        _map = new Box[Height, Width];
        List<int> generatedMap = _wrapperAlgo.mapGeneration(Height * Width, Enum.GetNames(typeof(EBoxType)).Length);
        convertIntListToMap(generatedMap);
    }

    /// <summary>
    /// Set the box on the map according to the line and column
    /// </summary>
    /// <param name="box">The box</param>
    /// <param name="line">The box's line</param>
    /// <param name="column">The box's coluln</param>
    public void setBox(Box box, int line, int column) {
        _map[line, column] = box;
    }

    /// <summary>
    /// Get the box located at the line and column.
    /// </summary>
    /// <param name="line">The line of the wanted box</param>
    /// <param name="column">The column of the wanted box</param>
    /// <returns>The box</returns>
    public virtual Box getBox(int line, int column) {
        return _map[line, column];
    }

    /// <summary>
    /// Get the map
    /// </summary>
    /// <returns>The map (2D array of box)</returns>
    public Box[,] getMap() {
        return _map;
    }

    /// <summary>
    /// Return a list containing a list of the init coordonates. The first coordonate correspond to the line, the second to the column
    /// </summary>
    /// <returns>A list containing a list of the init coordonates (2 elements in this list)</returns>
    public virtual IEnumerable<IEnumerable<int>> getInitCoordonates() {
        List<int> coord = _wrapperAlgo.initCoordonates(convertMapToIntList(), Width * Height);

        List<List<int>> initCoord = new List<List<int>>();
        initCoord.Add(convertIntToCoordonates(coord[0]));
        initCoord.Add(convertIntToCoordonates(coord[1]));

        return initCoord;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public Map() {
        _wrapperAlgo = new Wrapper.WrapperAlgo();
        _boxFactory = new BoxFactory();
    }

    /// <summary>
    /// Convert an int to a coordonate : a list with line number (at index 0) and column (at 1 index)
    /// </summary>
    /// <param name="coord">The int coordonate (line*width+column)</param>
    /// <returns>A list : [line,column]</returns>
    protected List<int> convertIntToCoordonates(int coord) {
        List<int> l = new List<int>();

        //We first add the line
        l.Add(coord / Width);
        //Then the column
        l.Add(coord % Width);

        return l;
    }

   /// <summary>
   /// Check if there is water around the tile line,column (diagonal direction included).
   /// </summary>
   /// <param name="line">The line of the tile</param>
    /// <param name="column">The column of the tile</param>
   /// <returns>True if there is water around the tile, false otherwise.</returns>
    public bool waterAround(int line, int column) {

        for(int i = line-1; i <= line+1; i++)
            for(int j = column-1; j <= column+1; j++)
                if(!outOfMap(i, j) && (i != line || j != column)) // If we are not out of the map and not on the box
                    if(_map[i, j].GetType() == typeof(SeaBox))
                        return true;
        
        return false;
    }

    /// <summary>
    /// Check if the coordonates are still in the map
    /// </summary>
    /// <param name="line">The line</param>
    /// <param name="column">The column</param>
    /// <returns>True if the coordonates are inside the map, false otherwise.</returns>
    public bool outOfMap(int line, int column) {
        return line < 0 || line >= Height || column < 0 || column >= Width;
    }

    /// <summary>
    /// Convert a Box[,] to a List of int according to the size of the map. The int correspond to EBoxType.
    /// </summary>
    /// <returns>A list of int representing the map</returns>
    public List<int> convertMapToIntList() {
        List<int> l = new List<int>();

        for(int line = 0; line < Height; line++) {
            for(int column = 0; column < Width; column++) {
                if(_map[line, column].GetType() == typeof(DesertBox))
                    l.Add((int)EBoxType.DESERT);

                if(_map[line, column].GetType() == typeof(ForestBox))
                    l.Add((int)EBoxType.FOREST);

                if(_map[line, column].GetType() == typeof(LowlandBox))
                    l.Add((int)EBoxType.LOWLAND);

                if(_map[line, column].GetType() == typeof(MountainBox))
                    l.Add((int)EBoxType.MOUNTAIN);

                if(_map[line, column].GetType() == typeof(SeaBox))
                    l.Add((int)EBoxType.SEA);
            }
        }
        return l;
    }

    /// <summary>
    /// Convert a List of int (EBoxType) to a Box[,] according to the size of the map. Changes the current map.
    /// </summary>
    /// <param name="l">The list of int representing the map.</param>
    public void convertIntListToMap(List<int> l) {
        for(int line = 0; line < Height; line++) {
            for(int column = 0; column < Width; column++) {
                switch(l[line * Width + column]) {
                    case (int)EBoxType.DESERT:
                        setBox(_boxFactory.getBox(EBoxType.DESERT), line, column);
                        break;

                    case (int)EBoxType.FOREST:
                        setBox(_boxFactory.getBox(EBoxType.FOREST), line, column);
                        break;

                    case (int)EBoxType.LOWLAND:
                        setBox(_boxFactory.getBox(EBoxType.LOWLAND), line, column);
                        break;

                    case (int)EBoxType.MOUNTAIN:
                        setBox(_boxFactory.getBox(EBoxType.MOUNTAIN), line, column);
                        break;

                    case (int)EBoxType.SEA:
                        setBox(_boxFactory.getBox(EBoxType.SEA), line, column);
                        break;
                }
            }
        }
    }
}

