using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] public Vector3 defDistanceToTarget = new Vector3(0f, 2f, -10f);
    [SerializeField] public float distanceDamp = 0.15f;
    [SerializeField] float rotationDamp = 10f;


    Transform myT;
    public Vector3 velocity = Vector3.one;


    void Awake()
    {
        myT = transform;
    }



   bool FindTarget()
    {
        if(target == null)
        {
            GameObject temp =  GameObject.FindGameObjectWithTag("Player");
            if(temp != null)
                target = temp.transform;
        }


        if(target == null)
            return false;

        return true;
    }



   void LateUpdate() {
       if(!FindTarget())
           return;


       SmoothFollow();
    //    Vector3 toPos = target.position + (target.rotation * defDistanceToTarget);
    //    Vector3 curPos = Vector3.Lerp(myT.position, toPos, distanceDamp * Time.deltaTime);
    //    myT.position = curPos;

      //  Quaternion toRot = Quaternion.LookRotation(target.position - myT.position, target.up);
       // Quaternion curRot = Quaternion.Slerp(myT.rotation, toRot, rotationDamp * Time.deltaTime);   

       // myT.rotation = curRot;
   }


    void SmoothFollow()
    {
       Vector3 toPos = target.position + (target.rotation * defDistanceToTarget);
       Vector3 curPos = Vector3.SmoothDamp(myT.position, toPos, ref velocity, distanceDamp);
       myT.position = curPos;
       myT.LookAt(target, target.up);
    }



}
