using UnityEngine;
using System.Collections.Generic;

public class StarSystem : ISpaceGameObject {

    #region properties

    public string name { get; private set; } // Name of the star - currently the position to generate, will eventualy use a name list?
    public Vector3 position { get; private set; } // Location of the system in the galaxy.
    public string type { get; private set; }

    public List<Body> systemBodies { get; private set; } // List of bodies in the system.

    #endregion ----------------


    public StarSystem(Vector3 _starPosiiton, List<Body> bodyList)
    {
        position = _starPosiiton;
        name = "star_" + position.x + "_" + position.y;
        type = "star";

        systemBodies = bodyList;

    }


}
