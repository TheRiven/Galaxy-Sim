using UnityEngine;
using System.Collections.Generic;

public class SpriteController : MonoBehaviour {

    #region properties

    Dictionary<StarSystem, GameObject> starSystemsDictionary; // Dictionary of Stars and their GameObjects

    public static SpriteController instance; // Static Instance of the SpriteController for easy access.

    public Sprite defaultStarSprite; // Basic star sprite
    public Sprite selectionSprite; // Basic selection sprite

    StarSystem selectedStar; // The currently selected star.
    GameObject selectionCircle; // The object showing the selected star.

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

        // Add a collider to allow raycasting.
        starGO.AddComponent<BoxCollider>();

    }


    public void ClearStarGameObjects()
    {
        // Destroys all of the Game Objects
        foreach (StarSystem star in starSystemsDictionary.Keys)
        {
            Destroy( starSystemsDictionary[star] );
        }

        // Resets the Dictionary
        starSystemsDictionary = new Dictionary<StarSystem, GameObject>();

    }


    public void SelectStarSystem(StarSystem star)
    {

        if (selectedStar != star)
        {
            selectedStar = star;

            if (selectionCircle != null)
                Destroy(selectionCircle);

            selectionCircle = new GameObject("Selection_Circle");
            selectionCircle.transform.position = star.starPosition;

            // add the sprite renderer.
            SpriteRenderer sr = selectionCircle.AddComponent<SpriteRenderer>();
            sr.sprite = selectionSprite;

        }

    }


    public void ClearSelection()
    {
        selectedStar = null;

        if (selectionCircle != null)
            Destroy(selectionCircle);

    }


    public StarSystem GetStarSystemFromGameObject(GameObject gameObject)
    {

        foreach (KeyValuePair<StarSystem, GameObject> kvp in starSystemsDictionary)
        {
            if (gameObject == kvp.Value)
            {
                return kvp.Key;
            }
        }

        Debug.LogError("GetStarSystemFromGameObject -- GameObject not found in Dictionary");
        return null;
    }

}
