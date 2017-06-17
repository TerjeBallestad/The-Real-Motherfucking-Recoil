using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.CorgiEngine;

public class ammoText : MonoBehaviour {

    public GameObject skuddText, skuddShade;
    private Text ammoTekst, ammoSkygge;

    void Start ()
    {
        ammoTekst = skuddText.GetComponent<Text>();
        ammoSkygge = skuddShade.GetComponent<Text>();
    }
	
	// Update is called once per frame
	

    public void updateAmmo(int CurrentAmmo, int MagazineSize)
    {
        ammoTekst.text = (CurrentAmmo + "/" + MagazineSize).ToString();
        ammoSkygge.text = (CurrentAmmo + "/" + MagazineSize).ToString();
    }
}
