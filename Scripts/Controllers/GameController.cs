using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

    #region Properties

    // Size of the galaxy
    public int height;
    public int width;

    // DEBUG Options
    //public bool DrawGizmosON = false;

    
    // MAP GEN ------

    // Seed for map generation
    public string seed;

    // Star generation density
    [Range(0, 100)]
    public int maxDensity = 100;

    // END MAP GEN ------

    Galaxy theGalaxy;

    public static GameController instance;

    #endregion ----------------

    // Use this for initialization
    void Start ()
    {
        instance = this;

        theGalaxy = MapGenerator.GenerateGalaxy(seed, height, width, maxDensity);
        

        ViewController.instance.DisplayGalaxy();

	}
        

    // Update is called once per frame
    void Update ()
    {   

    }
    
    
    public Galaxy GetCurrentGalaxy()
    {
        return theGalaxy;
    }
            

    /*    Debug Gizmos - Broken as of map gen rework
    void OnDrawGizmos()
    {
        if (DrawGizmosON == false)
        {
            return;
        }


        if(starMap != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Gizmos.color = (starMap[x, y] == 1) ? Color.black : Color.white;
                    Vector3 pos = new Vector3(-width / 2 + x + .5f, -height / 2 + y + .5f, 0 );
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }

        }
    }
    */

    

}
