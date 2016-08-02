using UnityEngine;
using System.Collections.Generic;

public class SpriteController : MonoBehaviour {

    #region properties

    Dictionary<StarSystem, GameObject> starSystemsDictionary;

    public static SpriteController instance;

    public Sprite defaultStarSprite;

    #endregion ---------------


    // Use this for initialization
    void OnEnable ()
    {
        instance = this;
        starSystemsDictionary = new Dictionary<StarSystem, GameObject>();
	}
	

	// Update is called once per frame
	void Update ()
    {
	
	}


    public void CreateStarGameObjects(StarSystem star)
    {
        // Create and setup the Star Gameobjects.
        GameObject starGO = new GameObject(star.starName);
        starGO.transform.SetParent(this.transform);
        starGO.transform.position = star.starPosition;
        starSystemsDictionary.Add(star, starGO);

        // add the sprite renderer.
        SpriteRenderer sr = starGO.AddComponent<SpriteRenderer>();
        sr.sprite = defaultStarSprite;
        

    }


    public void ClearStarGameObjects()
    {

        foreach (StarSystem star in starSystemsDictionary.Keys)
        {
            Destroy( starSystemsDictionary[star] );
        }

        starSystemsDictionary = new Dictionary<StarSystem, GameObject>();

    }


}
