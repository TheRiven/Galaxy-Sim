using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RightInfoPanel : MonoBehaviour {

    #region properties

    Text rightMenuText;

    #endregion ---------------

    // Use this for initialization
    void OnEnable()
    {
        rightMenuText = gameObject.GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}


    public void DisplayText(string textToDisplay)
    {
        rightMenuText.text = textToDisplay;
    }
}
