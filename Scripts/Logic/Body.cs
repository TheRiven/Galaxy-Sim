using UnityEngine;
using System.Collections;

public class Body : ISpaceGameObject {


    #region properties

    // ISpaceGameObject
    public Vector3 position { get; private set; } // Location of the system in the Star System.
    public string name { get; private set; } // Name of the body - currently using the position to generate, will eventualy use a name list?
    public objectType type { get; private set; } // What type of object this is. Used by the SpriteController
    // END ISpaceGameObject

    #endregion ----------------


    public Body(Vector3 pos, string _name, objectType _type)
    {
        position = pos;
        name = _name;
        type = _type;
    }


}
