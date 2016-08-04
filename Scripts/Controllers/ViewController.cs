using UnityEngine;
using System.Collections;


enum VIEWMODE
{
    GALAXY,
    STARSYSTEM
}


public class ViewController : MonoBehaviour {

    #region properties

    VIEWMODE viewMode = VIEWMODE.GALAXY;

    public static ViewController instance;
    
    #endregion ---------------

    // Use this for initialization
    void OnEnable ()
    {
        instance = this;

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}


    public void DisplayGalaxy()
    {
        
        foreach (StarSystem system in GameController.instance.GetCurrentGalaxy().Systems)
        {
            SpriteController.instance.CreateStarGameObjects(system);
        }

    }


}
