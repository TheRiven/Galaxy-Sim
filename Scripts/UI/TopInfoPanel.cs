using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TopInfoPanel : MonoBehaviour {

    #region properties

    Text topMenuText;

    #endregion ---------------

    // Use this for initialization
    void OnEnable()
    {
        topMenuText = gameObject.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {


	}


    public void DisplayText(string textToDisplay)
    {
        topMenuText.text = textToDisplay;
    }

}
