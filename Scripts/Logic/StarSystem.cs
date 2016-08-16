using UnityEngine;
using System.Collections.Generic;

public class StarSystem : ISpaceGameObject {

    #region properties

    // ISpaceGameObject
    public string name { get; private set; } // Name of the star - currently using the position to generate, will eventualy use a name list?
    public Vector3 position { get; private set; } // Location of the system in the galaxy.
    public objectType type { get; private set; } // What type of object this is. Used by the SpriteController
    // END ISpaceGameObject

    public List<Body> systemBodies { get; private set; } // List of bodies in the system.

    #endregion ----------------


    public StarSystem(Vector3 _starPosiiton, List<Body> bodyList)
    {
        position = _starPosiiton;
        name = "star_" + position.x + "_" + position.y;
        type = objectType.STAR;

        systemBodies = bodyList;

    }


}
