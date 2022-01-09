using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
[SerializeField]Transform target;
[SerializeField]LasersManager laser;

Vector3 hitPos;

    void Start()
    {
        
    }

    void Update()
    {
        if(!FindTarget())
            return;


       inFront();
       haveLineOfSight();
       if(inFront() && haveLineOfSight())
       {
           FireLaser();
       }

    }


    bool inFront()
    {
        Vector3 dirToTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, dirToTarget);

        if(Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            return true;
        }
        return false;

    }

    bool haveLineOfSight()
    {
        RaycastHit hit;
        Vector3 direction = target.position - transform.position;
        if(Physics.Raycast(laser.transform.position, direction, out hit, laser.Distance))
        {
            if(hit.transform.CompareTag("Player"))
            {
                hitPos = hit.transform.position;
                return true;
            }
        }
        return false;
    }

    void FireLaser()
    {
        laser.FireLaserPos(hitPos, target);
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

}
