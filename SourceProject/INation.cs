﻿using System;
using System.Collections.Generic;


namespace SourceProject {
    interface INation {
        Unit getUnit(int i);
        IEnumerable<Unit> getUnits();
        int getUnitsNumber();
        bool setInitBox(int line, int column, Map m);
    }
}
