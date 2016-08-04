using UnityEngine;
using System.Collections;


public enum VIEWMODE
{
    NONE,
    GALAXY,
    STARSYSTEM
}


public class ViewController : MonoBehaviour {

    #region properties

    public VIEWMODE viewMode { get; private set; }

    public static ViewController instance;
    
    #endregion ---------------

    // Use this for initialization
    void OnEnable ()
    {
        instance = this;
        viewMode = VIEWMODE.NONE;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}


    public void DisplayGalaxy()
    {
        if (viewMode == VIEWMODE.GALAXY)
        {
            return;
        }

        viewMode = VIEWMODE.GALAXY;

        Camera.main.transform.position = new Vector3(GameController.instance.width / 2, GameController.instance.height / 2, -10);

        SpriteController.instance.ClearGameObjects();

        foreach (StarSystem system in GameController.instance.GetCurrentGalaxy().Systems)
        {
            SpriteController.instance.CreateGameObjects(system);
        }

    }


    public void DisplaySystem(StarSystem star)
    {
        if (viewMode == VIEWMODE.STARSYSTEM)
        {
            return;
        }

        viewMode = VIEWMODE.STARSYSTEM;

        Camera.main.transform.position = new Vector3(0, 0, -10);

        SpriteController.instance.ClearGameObjects();

        foreach (Body body in star.systemBodies)
        {
            SpriteController.instance.CreateGameObjects(body);
        }


    }

}
