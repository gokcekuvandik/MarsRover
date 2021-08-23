using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.Model
{
    public enum CompassDirection
    {
        N = 90,         //North
        W = 180,        //West
        S = 270,        //South
        E = 0,          //East
    }

    public enum PointingDirection
    {
        R = -90,
        L = 90
    }
}
