using UnityEngine;
using System.Collections.Generic;

public class SpriteController : MonoBehaviour {

    #region properties

    Dictionary<ISpaceGameObject, GameObject> gameObjectDictionary; // Dictionary of Space objects and their GameObjects.

    public static SpriteController instance; // Static Instance of the SpriteController for easy access.

    public Sprite defaultStarSprite;    // Basic star sprite
    public Sprite selectionSprite;      // Basic selection sprite
    public Sprite sunSprite;            // Basic Sun Sprite
    public Sprite planetSprite;         // Basic Planet Sprite

    GameObject selectionCircle; // The object showing the selected star.

    #endregion ---------------


    // Use this for initialization
    void OnEnable ()
    {
        instance = this;
        gameObjectDictionary = new Dictionary<ISpaceGameObject, GameObject>();

    }
	

	// Update is called once per frame
	void Update ()
    {
	
	}


    public void CreateGameObjects(ISpaceGameObject spaceObject)
    {
        // Create and setup the Gameobjects.
        GameObject starGO = new GameObject(spaceObject.name);
        starGO.transform.SetParent(this.transform);
        starGO.transform.position = spaceObject.position;
        gameObjectDictionary.Add(spaceObject, starGO);

        // add the sprite renderer.
        SpriteRenderer sr = starGO.AddComponent<SpriteRenderer>();

        switch (spaceObject.type)
        {
            case objectType.STAR : sr.sprite = defaultStarSprite;
                break;
            case objectType.SUN  : sr.sprite = sunSprite;
                break;
            case objectType.PLANET : sr.sprite = planetSprite;
                break;
        }

        // Add a collider to allow raycasting.
        starGO.AddComponent<BoxCollider>();

    }

    
    public void ClearGameObjects()
    {
        // Destroys all of the Game Objects
        foreach (ISpaceGameObject spaceObject in gameObjectDictionary.Keys)
        {
            Destroy(gameObjectDictionary[spaceObject]);
        }

        // Resets the Dictionary
        gameObjectDictionary = new Dictionary<ISpaceGameObject, GameObject>();
    }

    
    public void DisplaySelectedStarSystem(StarSystem star)
    {
        if (selectionCircle != null)
            Destroy(selectionCircle);

        selectionCircle = new GameObject("Selection_Circle");
        selectionCircle.transform.position = star.position;

        // add the sprite renderer.
        SpriteRenderer sr = selectionCircle.AddComponent<SpriteRenderer>();
        sr.sprite = selectionSprite;

    }


    public void ClearDisplayedSelection()
    {
        if (selectionCircle != null)
            Destroy(selectionCircle);
    }


    public StarSystem GetStarSystemFromGameObject(GameObject gameObject)
    {

        foreach (KeyValuePair<ISpaceGameObject, GameObject> kvp in gameObjectDictionary)
        {
            if (gameObject == kvp.Value)
            {
                return (StarSystem)kvp.Key;
            }
        }

        Debug.LogError("GetStarSystemFromGameObject -- GameObject not found in Dictionary");
        return null;
    }

}
