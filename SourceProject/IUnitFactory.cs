using System;
namespace SourceProject {
    interface IUnitFactory<out T> {
        System.Collections.Generic.IEnumerable<Unit> getUnits(int unitNumber);
    }
}
