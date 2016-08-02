using UnityEngine;
using System.Collections.Generic;
using System;

public class Galaxy {

    #region Properties

    public List<StarSystem> Systems { get; private set; }

    #endregion ----------------


    public Galaxy(int[,] starMap)
    {
        Systems = new List<StarSystem>();
        CreateStarSystems(starMap);


    }

    void CreateStarSystems(int[,] starMap)
    {

        for (int x = 0; x < starMap.GetLength(0); x++)
        {
            for (int y = 0; y < starMap.GetLength(1); y++)
            {
                if (starMap[x,y] == 1)
                {
                    Vector3 starPos = new Vector3(x, y);

                    StarSystem newSystem = new StarSystem(starPos);
                    //Debug.Log("New Starsystem created at: " + starPos.ToString() );

                    Systems.Add(newSystem);
                    SpriteController.instance.CreateStarGameObjects(newSystem);
                    
                }
            }
        }


    }

}
