using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
[SerializeField]LasersManager[] laser;
[SerializeField]FollowCam fcam;


void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach(LasersManager l in laser)
            {
                Vector3 pos = transform.position + (transform.forward * l.Distance);
                l.FireLaser();
            }
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            fcam.defDistanceToTarget = new Vector3(0f,0f,0f);
            fcam.distanceDamp = 0f;
        }
        if(Input.GetKeyUp(KeyCode.V))
        {
            fcam.defDistanceToTarget = new Vector3(0f,2f,-10f);
            fcam.distanceDamp = 0.15f;
        }

    }
}
