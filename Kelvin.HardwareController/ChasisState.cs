using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelvin.HardwareController {

    public enum ChasisState {

        NotReady = 0,
        Obstructed = 1,
        Ready = 2,
        InMove = 4,
        TurnLeft = 8,
        TurnRight = 16
    }
}