using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]Transform target;
    [SerializeField]float rotationDamp = .5f;
    [SerializeField]float movespeed = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        Turn();
        Move();
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




}
