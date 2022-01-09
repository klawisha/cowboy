using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    Transform myT;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        myT = transform;
    }

    // Update is called once per frame
    void Update()
    {
        myT.position = Input.mousePosition;
    }
}
