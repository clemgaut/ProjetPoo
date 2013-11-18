using System;
namespace SourceProject
{
    interface IMap
    {
        void addNation(Nation nation);
        void genererCarte();
        System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable<int>> getInitCoordonates();
        void refreshMap();
        void setBox(Box box, int x, int y);
        void showMap();
    }
}
