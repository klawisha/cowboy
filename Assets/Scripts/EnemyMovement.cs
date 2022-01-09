using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Explosion))]
[RequireComponent(typeof(TrailRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField]Transform target;
    [SerializeField]float rotationDamp = .5f;
    [SerializeField]float movespeed = 10f;

    [SerializeField]float detectionDist = 20f;
    [SerializeField]float rayCastOffset = 2.5f;

    void Start()
    {
        
    }

    void Update()
    {
        if(!FindTarget())
            return;
        PathFinding();
        //Turn();:
        Move();
    }


    void OnEnable()
    {
        EventManager.onPlayerDeath += FindCamera;
        EventManager.onStartGame += SelfDestruct;
    }

    void OnDisable()
    {
        EventManager.onPlayerDeath -= FindCamera;
        EventManager.onStartGame -= SelfDestruct;
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }


    void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationDamp * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * movespeed * Time.deltaTime;
    }

    void PathFinding()
    {
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;
        Vector3 l = transform.position - transform.right * rayCastOffset;
        Vector3 r = transform.position + transform.right * rayCastOffset;
        Vector3 u = transform.position + transform.up * rayCastOffset;
        Vector3 d = transform.position - transform.up * rayCastOffset;
  
        Debug.DrawRay(l, transform.forward * detectionDist, Color.cyan);

        if(Physics.Raycast(l, transform.forward, out hit, detectionDist))
        {
            raycastOffset += Vector3.right;
        }
        else if(Physics.Raycast(r, transform.forward, out hit, detectionDist))
        {
            raycastOffset -= Vector3.right;
        }
        
        if(Physics.Raycast(u, transform.forward, out hit, detectionDist))
        {
            raycastOffset -= Vector3.up;
        }
        else if(Physics.Raycast(d, transform.forward, out hit, detectionDist))
        {
            raycastOffset += Vector3.up;
        }

        if(raycastOffset != Vector3.zero)
            transform.Rotate(raycastOffset * 5f * Time.deltaTime);
        else
        {
            Turn();
        }

   }

   bool FindTarget()
    {
        if(target == null){
        
           GameObject temp =  GameObject.FindGameObjectWithTag("Player");
            if(temp != null)
                target = temp.transform;
        }
    
        if(target == null)
            return false;

        return true;
    }

    void FindCamera()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

}
