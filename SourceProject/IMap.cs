using System;
using System.Collections.Generic;
namespace SourceProject {
    /// <summary>
    /// Interface for the map
    /// </summary>
    interface IMap {
        void generateMap();
        void setBox(Box box, int line, int column);
        Box getBox(int line, int column);
        Box[,] getMap();
        IEnumerable<IEnumerable<int>> getInitCoordonates();
        bool waterAround(int line, int column);
        bool outOfMap(int line, int column);
        List<int> convertMapToIntList();
        void convertIntListToMap(List<int> l);
    }
}
