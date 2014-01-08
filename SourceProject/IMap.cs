using System;
using System.Collections.Generic;
namespace SourceProject {
    /// <summary>
    /// Interface for the map
    /// </summary>
    interface IMap {
        public virtual void generateMap();
        public void setBox(Box box, int line, int column);
        public virtual Box getBox(int line, int column);
        public Box[,] getMap();
        public virtual IEnumerable<IEnumerable<int>> getInitCoordonates();
        protected List<int> convertIntToCoordonates(int coord);
        public bool waterAround(int line, int column);
        public bool outOfMap(int line, int column);
        public List<int> convertMapToIntList();
        public void convertIntListToMap(List<int> l);
    }
}
