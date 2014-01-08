using System;
using System.Collections.Generic;


namespace SourceProject {
    /// <summary>
    /// Interface for the nation
    /// </summary>
    interface INation {
        int getUnitsNumber();
        List<Unit> getUnits();
        void deleteDeadUnits();
        Unit getUnit(int i);
        List<Unit> getUnits(int line, int column);
        bool setInitBox(int line, int column, Map m);
        void moveToNullPosition();
    }
}
