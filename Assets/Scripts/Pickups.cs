using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(CapsuleCollider))]
public class Pickups : MonoBehaviour
{
    static int points = 50;
    Transform myT;
    Vector3 randRot;
    [SerializeField]float rotOffset = 100f;

    void Awake()
    {
        myT = transform;
    }


    void Start()
    {
        randRot.x = Random.Range(-rotOffset, rotOffset);
        randRot.y = Random.Range(-rotOffset, rotOffset);
        randRot.z = Random.Range(-rotOffset, rotOffset);
    }

    void Update()
    {
        myT.Rotate(randRot * Time.deltaTime);
    }


    void OnTriggerEnter(Collider col)
    {
       if(col.transform.CompareTag("Player"))
       {
            PickupHit();
       }

    }


    public void PickupHit()
    {

        Destroy(gameObject);
    }


}
