using System;
using System.Collections.Generic;
namespace SourceProject {
    interface IPlayer {
        string getName();
        Nation getNation();
        List<Unit> getSelectableUnits();
        void refresh();
        void setNation(Nation nation);
    }
}
