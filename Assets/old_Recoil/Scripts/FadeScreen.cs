using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour {

    public static FadeScreen Instance { set; get; }

    public Image fadeImage;
    public Text fadeText;
    private bool isInTransition, isShowing;
    private float duration, transition;

    private void Awake()
    {
        Instance = this;
    }

    public void Fade(bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Fade(true, 1.2f);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Fade(false, 0.9f);
        }

        if (!isInTransition)
            return;

        transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        fadeImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
        fadeText.color = Color.Lerp(new Color(0, 0, 0, 0), Color.red, transition);

        if (transition > 1 || transition < 0)
            isInTransition = false;
    }
}
