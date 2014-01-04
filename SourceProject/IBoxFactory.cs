using System;
namespace SourceProject {
    /// <summary>
    /// Interface for the box factory
    /// </summary>
    interface IBoxFactory {
        Box getBox(EBoxType boxType);
    }
}
