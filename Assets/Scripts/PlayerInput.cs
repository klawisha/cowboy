using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerInput : MonoBehaviour
{
[SerializeField]LasersManager[] laser;
//[SerializeField]GameObject fcam;
[SerializeField]PlayerMovement pmv;

int LEFT_MOUSE_BTN  = 0;
int RIGHT_MOUSE_BTN = 1;
float ShiftForce = 50f;

void Start()
{
       // fcam = GameObject.FindGameObjectWithTag("MainCamera");
}

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

        if(Input.GetMouseButtonDown(LEFT_MOUSE_BTN))
        {
            foreach(LasersManager l in laser)
            {
                Vector3 pos = transform.position + (transform.forward * l.Distance);
                l.FireLaser();
            }

        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
           pmv.movement_speed += ShiftForce;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            pmv.movement_speed -= ShiftForce;
        }

        if(Input.GetMouseButtonDown(RIGHT_MOUSE_BTN))
        {
        }


       /* if(Input.GetKeyDown(KeyCode.V))
        {
            fcam.GetComponent<FollowCam>.defDistanceToTarget = new Vector3(0f,0f,0f);
            fcam.GetComponent<FollowCam>.distanceDamp = 0f;
        }
        if(Input.GetKeyUp(KeyCode.V))
        {
            fcam.GetComponent<FollowCam>.defDistanceToTarget = new Vector3(0f,2f,-10f);
            fcam.GetComponent<FollowCam>.distanceDamp = 0.15f;
        }*/

    }
}
