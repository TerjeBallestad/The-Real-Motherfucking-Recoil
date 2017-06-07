using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyBarScript : MonoBehaviour {

    public float eFillAmount;
    public Image EHBSlider;
    public GameObject ehbCanvas;

    public void smHealthChange()
    {
        EHBSlider.fillAmount = Mathf.InverseLerp(0, StatControl.smMaxHealth, StatControl.smCurrentHealth);
    }

    void Start()
    {
        StatControl.smCurrentHealth = StatControl.smMaxHealth;
    }
    void Update()
    {
        smHealthChange();
        if (StatControl.smCurrentHealth <= 0)
        {
            Invoke("removeBar", 1.25f);
        }
    }

    void removeBar()
    {
//        ehbCanvas.SetActive(false);
    }
}
