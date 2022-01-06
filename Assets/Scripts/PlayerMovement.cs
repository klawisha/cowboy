using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movement_speed = 50.0f;
    [SerializeField] float turn_speed = 60.0f;
    [SerializeField]TrailsManager[] trails;


    Transform myT;

    void Awake() {
        myT = transform;
    }


    void Update() {
        Turn();
        Thrust();    
    }




    void Turn()
    {
        float yaw = turn_speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turn_speed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turn_speed * Time.deltaTime * Input.GetAxis("Roll");

        myT.Rotate(-pitch, yaw, -roll);
    }


    void Thrust()
    {
        if(Input.GetAxis("Vertical") > 0){
            myT.position += myT.forward * movement_speed * Time.deltaTime * Input.GetAxis("Vertical");
            
        foreach(TrailsManager t in trails)
            t.Intensity(Input.GetAxis("Vertical"));
        }
       // if(Input.GetKeyDown(KeyCode.W))
       //     foreach(TrailsManager t in trails)
       //         t.Activate();
       // else if(Input.GetKeyUp(KeyCode.W))
       //     foreach(TrailsManager t in trails)
       //         t.Activate(false);

    }
}
