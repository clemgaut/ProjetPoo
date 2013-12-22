using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NainUnit : Unit {
    public NainUnit() {
    }

    public override int getPoint(Map m) {
        Box b = m.getBox(_line, _column);

        if(b.GetType() == typeof(ForestBox))
            return 2;
        else if(b.GetType() == typeof(LowlandBox))
            return 0;
        else
            return 1;
    }

}

