using System;
namespace SourceProject
{
    interface IUnitFactory
    {
        System.Collections.Generic.IEnumerable<Unit> getUnits(int unitNumber);
    }
}
