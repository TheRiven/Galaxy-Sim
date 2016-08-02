using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

    #region Properties

    // Size of the galaxy
    public int height;
    public int width;


    // DEBUG Options
    public bool DrawGizmosON = false;

    // MAP GEN ------

    // Seed for map generation
    public string seed;

    [Range(0, 100)]
    public int maxDensity = 100;

    // 2 dimensional array of stars
    int[,] starMap;

    MapGenerator mapGen;

    // END MAP GEN ------

    Galaxy theGalaxy;

    Vector3 currFramePostion;
    Vector3 lastFramePostion;

    #endregion ----------------

    // Use this for initialization
    void Start ()
    {
        mapGen = new MapGenerator();
        GenerateMap();

        Camera.main.transform.position = new Vector3(width / 2, height / 2, - 10);

	}
        

    // Update is called once per frame
    void Update ()
    {
                
        currFramePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(1) || Input.GetMouseButton(2) )
        {
            CameraScrolling();
        }

        CameraZooming();

        lastFramePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }


    void GenerateMap()
    {
        starMap = mapGen.GenerateRandomStars(seed, height, width, maxDensity);

        theGalaxy = new Galaxy(starMap);

    }
    
        
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


    void CameraScrolling() // Handle screen dragging
    {
        // FIXME: needs to set a limit to how far you can move the camera so that you don't get lost.

        //Debug.Log ("Current Mouse Position: " + currFramePostion);
        Vector3 diff = lastFramePostion - currFramePostion;
        Camera.main.transform.Translate(diff);

    }


    void CameraZooming() // Allows the scroll wheel to alter the camera zoom level
    {
        Camera.main.orthographicSize -= Camera.main.orthographicSize * Input.GetAxis("Mouse ScrollWheel");
        // Restricts the zoom level to within size 3 to 25
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 5f, 25f);
    }

}
