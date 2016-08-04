using UnityEngine;
using System.Collections;

public class Body : ISpaceGameObject {


    #region properties

    public Vector3 position { get; private set; }
    public string name { get; private set; }
    public string type { get; private set; }

    #endregion ----------------


    public Body(Vector3 pos, string _name, string _type)
    {
        position = pos;
        name = _name;
        type = _type;
    }


}
