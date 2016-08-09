using UnityEngine;
using System.Collections.Generic;

public static class MapGenerator {


    #region Generate Star Map

    static int[,] GenerateStarMap(string seed, int height, int width, int maxDensity )
    {
        string newSeed = seed;
        int[,] starMap = new int[width, height];

        if (newSeed == null || newSeed == "")
        {
            int one = Random.Range(0, 9);
            int two = Random.Range(0, 9);
            int three = Random.Range(0, 9);
            int four = Random.Range(0, 9);
            int five = Random.Range(0, 9);

            newSeed = "" + one + two + three + four + five;
            //Debug.Log("Random Seed generated: " + newSeed);
        }

        System.Random randomGen = new System.Random(newSeed.GetHashCode());
        int midY = height / 2;
        int midX = width / 2;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int distFromMid = (int)Mathf.Sqrt(Mathf.Pow(x - midX, 2) + Mathf.Pow(y - midY, 2));
                //Debug.Log("Tile :" + x + " " + y + " - Distance from mid = " + distFromMid);
                int density = maxDensity - distFromMid;
                //Debug.Log("Density = " + density);
                starMap[x, y] = (randomGen.Next(0, 100) < density) ? 1 : 0;

                SmoothMap(starMap, width, height, x, y);
            }
        }

        return starMap;
    }


    static void  SmoothMap(int[,] starMap, int width, int height, int currentStarX, int currentStarY)
    {

        int neighbourStars = GetSurroundingStarCount(currentStarX, currentStarY, width, height, starMap);
        if (neighbourStars >= 1)
            starMap[currentStarX, currentStarY] = 0;

    }
    

    static int GetSurroundingStarCount(int gridX, int gridY, int width, int height, int[,] starMap)
    {
        int wallCount = 0;
        for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
        {
            for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height)
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                    {
                        wallCount += starMap[neighbourX, neighbourY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }

        return wallCount;
    }

    #endregion ------------------


    #region Galaxy Generation

    public static Galaxy GenerateGalaxy(string seed, int height, int width, int maxDensity)
    {
        int[,] starMap = GenerateStarMap(seed, height, width, maxDensity);

        List<StarSystem> systems = CreateStarSystems(starMap);

        Galaxy newGalaxy = new Galaxy(systems);

        return newGalaxy;
    }


    static List<StarSystem> CreateStarSystems(int[,] starMap)
    {

        List<StarSystem> newSystemsList = new List<StarSystem>();

        for (int x = 0; x < starMap.GetLength(0); x++)
        {
            for (int y = 0; y < starMap.GetLength(1); y++)
            {
                if (starMap[x, y] == 1)
                {
                    Vector3 starPos = new Vector3(x, y);

                    List<Body> systemBodies = CreateSystemBodies();

                    StarSystem newSystem = new StarSystem(starPos, systemBodies);
                    //Debug.Log("New Starsystem created at: " + starPos.ToString() );

                    newSystemsList.Add(newSystem);

                }
            }
        }

        return newSystemsList;

    }

    #endregion ------------------


    #region Star System Generation

    static List<Body> CreateSystemBodies()
    {
        List<Body> systemBodies = new List<Body>();

        // Create the systems Sun
        Vector3 sunPosition = new Vector3(0,0,0);
        Body sun = new Body(sunPosition, "Sun", objectType.SUN);
        systemBodies.Add(sun);

        // TODO: create other system bodies.





        return systemBodies;
    }



    #endregion ------------------

}
