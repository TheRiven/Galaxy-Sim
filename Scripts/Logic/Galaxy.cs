using UnityEngine;
using System.Collections.Generic;
using System;

public class Galaxy {

    #region Properties

    public List<StarSystem> Systems { get; private set; }

    #endregion ----------------


    public Galaxy(List<StarSystem> _systems)
    {
        Systems = _systems;

    }

    

}
