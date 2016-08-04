using UnityEngine;
using System.Collections;

public class Body {


    #region properties

    public Vector3 position { get; private set; }

    public string name { get; private set; }

    #endregion ----------------


    public Body(Vector3 pos, string _name)
    {
        position = pos;
        name = _name;

    }


}
