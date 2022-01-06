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
                Debug.Log("Hit the " + hit.transform.name);
                hitPos = hit.transform.position;
                return true;
            }
        }
        return false;
    }

    void FireLaser()
    {
        laser.FireLaserPos(hitPos);
    }

}
