using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{
    [SerializeField] float minScale = .8f;
    [SerializeField] float maxScale = 1.8f;
  
    [SerializeField] float minRot = 100f;
    [SerializeField] float maxRot = -100f;
  
  
    Transform myT;
    Vector3 rand_rotation;


    void Awake() {
        myT = transform;
    }


    void Start() {
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale,maxScale);
        scale.y = Random.Range(minScale,maxScale);
        scale.z = Random.Range(minScale,maxScale);

        myT.localScale = scale;


        rand_rotation.x = Random.Range(minRot, maxRot);
        rand_rotation.y = Random.Range(minRot, maxRot);
        rand_rotation.z = Random.Range(minRot, maxRot);


    }


    void Update() {
        myT.Rotate(rand_rotation * Time.deltaTime);
    }
}
