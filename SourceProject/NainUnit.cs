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

    public override bool move(int line, int column, Map m) {
        bool move = canMove(line, column, m);
        if (move) {
            _line = line;
            _column = column;
            _movePoints--;
        }
        return move;
    }

    public override bool canMove(int line, int column, Map m) {
        if (_movePoints < 1)
            return false;
        if (_line < 0 || _column < 0) {
            if (m.getBox(line, column).GetType() == typeof(SeaBox))
                return false;
            else
                return true;
        } else {
            if (m.getBox(line, column).GetType() == typeof(MountainBox) && m.getBox(_line, _column).GetType() == typeof(MountainBox)) {
                return true;
            }
            if ((Math.Abs(line - _line) + Math.Abs(column - _column)) > 1
                || m.getBox(line, column).GetType() == typeof(SeaBox))
                return false;
            else {
                return true;
            }
        }
    }

}

