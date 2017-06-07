using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

    public float fillAmount;
    public Image HBSlider;
   
   public void HealthChange()
    {
        HBSlider.fillAmount = Mathf.InverseLerp(0, StatControl.maxHealth, StatControl.currentHealth);
    }

    void Start()
    {
        StatControl.currentHealth = StatControl.maxHealth;
    }
    void Update()
    {
        HealthChange();
    }

    

}
