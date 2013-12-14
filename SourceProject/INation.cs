using System;
using System.Collections.Generic;


namespace SourceProject
{
    interface INation
    {
        Unit getUnit(int i);
        IEnumerable<Unit> getUnits();
        int getUnitsNumber();
        void setInitBox(int line, int column);
    }
}
