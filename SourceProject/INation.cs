using System;
using System.Collections.Generic;


namespace SourceProject {
    /// <summary>
    /// Interface for the nation
    /// </summary>
    interface INation {
        Unit getUnit(int i);
        IEnumerable<Unit> getUnits();
        int getUnitsNumber();
        bool setInitBox(int line, int column, Map m);
    }
}
