using System;
using System.Collections.Generic;


namespace SourceProject {
    /// <summary>
    /// Interface for the nation
    /// </summary>
    interface INation {
        public virtual int getUnitsNumber();
        public virtual List<IUnit> getUnits();
        public virtual void deleteDeadUnits();
        public virtual IUnit getUnit(int i);
        public virtual List<IUnit> getUnits(int line, int column);
        public virtual bool setInitBox(int line, int column, IMap m);
        public void moveToNullPosition();
}
