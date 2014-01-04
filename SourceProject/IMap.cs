using System;
namespace SourceProject {
    /// <summary>
    /// Interface for the map
    /// </summary>
    interface IMap {
        void generateMap();
        System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable<int>> getInitCoordonates();
        void setBox(Box box, int x, int y);
    }
}
