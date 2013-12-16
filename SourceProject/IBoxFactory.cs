using System;
namespace SourceProject {
    interface IBoxFactory {
        Box getBox(EBoxType boxType);
    }
}
