using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    #region properties

    Vector3 currFramePostion;
    Vector3 lastFramePostion;

    StarSystem selectedStar; // The currently selected star.

    #endregion ---------------

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        // Camera Control
        currFramePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
            CameraScrolling();

        CameraZooming();
        lastFramePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Mouse Selection for Galaxy Mode
        if (Input.GetMouseButtonDown(0) & ViewController.instance.viewMode == VIEWMODE.GALAXY)
            SelectObject();

        if (Input.GetKeyDown(KeyCode.Space) & ViewController.instance.viewMode == VIEWMODE.STARSYSTEM)
            ViewController.instance.DisplayGalaxy();


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


    void SelectObject()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) )
        {
            GameObject gameObject = hit.collider.gameObject;

            StarSystem star = SpriteController.instance.GetStarSystemFromGameObject(gameObject);

            if (selectedStar != star)
            {
                selectedStar = star;
                SpriteController.instance.SelectStarSystem(star);
            }
            else
            {
                selectedStar = null;
                SpriteController.instance.ClearSelection();
                ViewController.instance.DisplaySystem(star);
            }

            
        }
        else
        {
            selectedStar = null;
            SpriteController.instance.ClearSelection();
        }


    }



}
