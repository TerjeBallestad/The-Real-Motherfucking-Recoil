using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHBFollow : MonoBehaviour {

    public GameObject shovelMan;
    private Vector3 offset = new Vector3(0, 3, 0);

    void Update()
    {
        transform.position = shovelMan.transform.position + offset;
    }
}
