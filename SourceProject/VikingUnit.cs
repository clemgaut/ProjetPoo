﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class VikingUnit : Unit {
    public VikingUnit() {
    }

    public override int getPoint(Map m) {
        Box b = m.getBox(_line, _column);
        int point;

        if(b.GetType() == typeof(DesertBox) || b.GetType() == typeof(SeaBox))
            point = 0;
        else 
            point = 1;
       
        if(m.waterAround(_line, _column))
            point++;

        return point;
    }
}

