using UnityEngine;
using System.Collections;

public class StarSystem {

    #region properties

    public Vector3 starPosition { get; private set; }

    #endregion ----------------


    public StarSystem(Vector3 _starPosiiton)
    {

        starPosition = _starPosiiton;

    }


}
