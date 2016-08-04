using UnityEngine;
using System.Collections.Generic;

public class StarSystem {

    #region properties

    public string starName { get; private set; } // Name of the star - currently the position to generate, will eventualy use a name list?

    public Vector3 starPosition { get; private set; } // Location of the system in the galaxy.

    public List<Body> systemBodies { get; private set; } // List of bodies in the system.

    #endregion ----------------


    public StarSystem(Vector3 _starPosiiton, List<Body> bodyList)
    {
        starPosition = _starPosiiton;
        starName = "star_" + starPosition.x + "_" + starPosition.y;

        systemBodies = bodyList;

    }


}
