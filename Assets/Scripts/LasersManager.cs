using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

[RequireComponent(typeof(Light))]
public class LasersManager : MonoBehaviour
{
[SerializeField]float laserOnTime = .2f;
[SerializeField]float maxDist = 300f;
LineRenderer lr;
Light laser_light;
bool canFire;
public float reload = 3f;


void Awake()
{
    lr = GetComponent<LineRenderer>();
    laser_light = GetComponent<Light>();
}

void Start()
{
    lr.enabled = false;
    laser_light.enabled = false;
    canFire = true;
}


Vector3 CastRay()
{
    RaycastHit hit;
    Vector3 fwd = transform.TransformDirection(Vector3.forward) * maxDist;

    if(Physics.Raycast(transform.position, fwd, out hit))
    {
        SpawnExplosion(hit.point, hit.transform);
        return hit.point;
    }
    return transform.position + (transform.forward * maxDist);
}

void SpawnExplosion(Vector3 hitPos, Transform target)
{
 Explosion temp = target.GetComponent<Explosion>();
        if(temp != null){
            temp.IveBeenHit(hitPos);
            temp.AddForce(hitPos, transform);
        }
}


public void FireLaser()
{
    /*
    if(canFire)
    {

    lr.SetPosition(0, transform.position);
    lr.SetPosition(1, CastRay());
    lr.enabled = true;
    laser_light.enabled = true;
    canFire = false;
    Invoke("TurnOffLaser", laserOnTime);
    Invoke("CanFire", reload);
    }*/
    Vector3 pos = CastRay();
    FireLaserPos(pos);
}

public void FireLaserPos(Vector3 targetPos, Transform target = null)
{
    if(canFire)
    {
    if(target != null)
    {
        SpawnExplosion(targetPos, target);
    }
    lr.SetPosition(0, transform.position);
    lr.SetPosition(1, targetPos);
    lr.enabled = true;
    laser_light.enabled = true;
    canFire = false;
    Invoke("TurnOffLaser", laserOnTime);
    Invoke("CanFire", reload);
    }

}


void TurnOffLaser()
{
    lr.enabled = false;
    laser_light.enabled = false;
//    canFire = true;
}

public float Distance
{
    get {return maxDist;}
}

void CanFire()
{
    canFire = true;
}


}
