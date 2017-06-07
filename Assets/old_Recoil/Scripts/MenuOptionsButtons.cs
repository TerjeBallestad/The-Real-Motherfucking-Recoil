using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptionsButtons : MonoBehaviour {

    public GameObject optionsMenu;
	
	void Start ()
    {
        optionsMenu = GameObject.Find("OptionsMenuMaster");
    }

    public void backToMain (string backToMain)
    {
        optionsMenu.SetActive(false);
    }

	
	
}
