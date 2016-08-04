using UnityEngine;
using System.Collections.Generic;

public class SpriteController : MonoBehaviour {

    #region properties

    Dictionary<StarSystem, GameObject> starSystemsDictionary; // Dictionary of Stars and their GameObjects
    Dictionary<Body, GameObject> bodyDictionary; // Dictionary of Bodies and their GameObjects

    public static SpriteController instance; // Static Instance of the SpriteController for easy access.

    public Sprite defaultStarSprite; // Basic star sprite
    public Sprite selectionSprite; // Basic selection sprite
    public Sprite sunSprite; // Basic Sun Sprite

    GameObject selectionCircle; // The object showing the selected star.

    #endregion ---------------


    // Use this for initialization
    void OnEnable ()
    {
        instance = this;
        starSystemsDictionary = new Dictionary<StarSystem, GameObject>();
        bodyDictionary = new Dictionary<Body, GameObject>();

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


    public void CreateBodyGameObjects(Body systemBody)
    {

        // Create and setup the Star Gameobjects.
        GameObject bodyGO = new GameObject(systemBody.name);
        bodyGO.transform.SetParent(this.transform);
        bodyGO.transform.position = systemBody.position;
        bodyDictionary.Add(systemBody, bodyGO);

        // add the sprite renderer.
        SpriteRenderer sr = bodyGO.AddComponent<SpriteRenderer>();
        sr.sprite = sunSprite;

        // Add a collider to allow raycasting.
        bodyGO.AddComponent<BoxCollider>();

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

    public void ClearBodyGameObjects()
    { 
        // Destroys all of the Game Objects
        foreach (Body body in bodyDictionary.Keys)
        {
            Destroy(bodyDictionary[body]);
        }

        // Resets the Dictionary
        bodyDictionary = new Dictionary<Body, GameObject>();

    }


    public void SelectStarSystem(StarSystem star)
    {
        if (selectionCircle != null)
            Destroy(selectionCircle);

        selectionCircle = new GameObject("Selection_Circle");
        selectionCircle.transform.position = star.starPosition;

        // add the sprite renderer.
        SpriteRenderer sr = selectionCircle.AddComponent<SpriteRenderer>();
        sr.sprite = selectionSprite;

    }


    public void ClearSelection()
    {
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
