using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailsManager : MonoBehaviour
{

    TrailRenderer tr;
    Light tr_light;
    // Start is called before the first frame update
    void Start()
    {
       // tr.enabled = false;
       // tr_light.enabled = false;
       tr_light.intensity = 0;
    }

    void Awake()
    {
        tr = GetComponent<TrailRenderer>();
        tr_light = GetComponent<Light>();
    }

    public void Activate(bool activate = true)
    {
        if(activate)
        {
            tr.enabled = true;
            tr_light.enabled = true;
        }
        else
        {
            tr.enabled = false;
            tr_light.enabled = false;
        }
    }
    public void Intensity(float inten)
    {
    tr_light.intensity = inten * 2; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
