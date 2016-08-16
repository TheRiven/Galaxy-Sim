using UnityEngine;
using System.Collections.Generic;

public class SpriteController : MonoBehaviour {

    #region properties

    Dictionary<ISpaceGameObject, GameObject> gameObjectDictionary; // Dictionary of Space objects and their GameObjects.

    List<GameObject> disposableObjects;

    public static SpriteController instance; // Static Instance of the SpriteController for easy access.

    public Sprite defaultStarSprite;    // Basic star sprite
    public Sprite selectionSprite;      // Basic selection sprite
    public Sprite sunSprite;            // Basic Sun Sprite
    public Sprite planetSprite;         // Basic Planet Sprite
    public Sprite orbitSprite;          // Basic Orbit Sprite

    GameObject selectionCircle; // The object showing the selected star.

    #endregion ---------------


    // Use this for initialization
    void OnEnable ()
    {
        instance = this;
        gameObjectDictionary = new Dictionary<ISpaceGameObject, GameObject>();
        disposableObjects = new List<GameObject>();

    }
	

	// Update is called once per frame
	void Update ()
    {
	
	}


    public void CreateGameObjects(ISpaceGameObject spaceObject)
    {
        // Create and setup the Gameobjects.
        GameObject go = new GameObject(spaceObject.name);
        go.transform.SetParent(this.transform);
        go.transform.position = spaceObject.position;
        gameObjectDictionary.Add(spaceObject, go);

        // add the sprite renderer.
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();

        switch (spaceObject.type)
        {
            case objectType.STAR :
                sr.sprite = defaultStarSprite;
                break;
            case objectType.SUN  :
                sr.sprite = sunSprite;
                break;
            case objectType.PLANET :
                sr.sprite = planetSprite;
                CreateOrbitalGameObject(go);
                break;
        }

        // Add a collider to allow raycasting.
        go.AddComponent<BoxCollider>();

    }


    void CreateOrbitalGameObject(GameObject orbitingObject)
    {
        // Create and setup the Gameobjects.
        GameObject go = new GameObject();
        go.transform.SetParent(this.transform);

        // add the sprite renderer.
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.sprite = orbitSprite;

        int radius = (int)Mathf.Sqrt(Mathf.Pow(orbitingObject.transform.position.x - 0, 2) + Mathf.Pow(orbitingObject.transform.position.y - 0, 2));

        go.transform.localScale = new Vector3(radius * 2, radius * 2, 1);

        disposableObjects.Add(go);

    }

    
    public void ClearGameObjects()
    {
        // Destroys all of the Game Objects
        foreach (ISpaceGameObject spaceObject in gameObjectDictionary.Keys)
        {
            Destroy(gameObjectDictionary[spaceObject]);
        }

        foreach(GameObject go in disposableObjects)
        {
            Destroy(go);
        }

        // Resets the Dictionary and list
        gameObjectDictionary = new Dictionary<ISpaceGameObject, GameObject>();
        disposableObjects = new List<GameObject>();

    }

    
    public void DisplaySelectedSpaceObject(ISpaceGameObject star)
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


    public ISpaceGameObject GetSpaceObjectFromGameObject(GameObject gameObject)
    {

        foreach (KeyValuePair<ISpaceGameObject, GameObject> kvp in gameObjectDictionary)
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
