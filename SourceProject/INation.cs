using System;
namespace SourceProject
{
    interface INation
    {
        void createUnits(int nombreUnites);
        Unit getUnit(int i);
        Unit[] getUnits();
        int getUnitsNumber();
        void setInitBox(int x, int y);
    }
}
