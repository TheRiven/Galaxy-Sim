using UnityEngine;
using System.Collections;

public static class MapGenerator {


    #region Generate Star Map

    public static int[,] GenerateRandomStars(string seed, int height, int width, int maxDensity )
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

}
