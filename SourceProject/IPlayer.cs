using System;
namespace SourceProject
{
    interface IPlayer
    {
        string getName();
        Nation getNation();
        Unit[] getSelectableUnits();
        void refresh();
        void setNation(Nation nation);
    }
}
