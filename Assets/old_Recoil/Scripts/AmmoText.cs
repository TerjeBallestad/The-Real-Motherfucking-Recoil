using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour {

    public GameObject ammoTekst, skyggeTekst;
    Text currentBullet, currentClip;

    void Start()
    {
        ammoTekst = GameObject.Find("bulletText");
        skyggeTekst = GameObject.Find("bulletShade");
    }

    void Update()
    {
        currentBullet = ammoTekst.GetComponent<Text>();
        currentClip = skyggeTekst.GetComponent<Text>();

        currentBullet.text = (StatControl.bulletCount + " / " + StatControl.clipSize);
        currentClip.text = (StatControl.bulletCount + " / " + StatControl.clipSize);
    }
    
	
}
