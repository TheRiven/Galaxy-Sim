using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    #region properties

    Vector3 currFramePostion;
    Vector3 lastFramePostion;

    #endregion ---------------

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        currFramePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            CameraScrolling();
        }

        CameraZooming();

        lastFramePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

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





}
