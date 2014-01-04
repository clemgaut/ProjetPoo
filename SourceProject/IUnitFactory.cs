using System;
namespace SourceProject {
    /// <summary>
    /// Interface for the unit factory
    /// </summary>
    /// <typeparam name="T">Class of the unit returned by the factory</typeparam>
    interface IUnitFactory<out T> {
        System.Collections.Generic.IEnumerable<Unit> getUnits(int unitNumber);
    }
}
