using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Explosion))]
public class Asteroid : MonoBehaviour
{
    [SerializeField] float minScale = .8f;
    [SerializeField] float maxScale = 1.8f;

    [SerializeField] float minRot = 100f;
    [SerializeField] float maxRot = -100f;

    public static float destructionDelay = 1.1f;

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

    public void SelfDestruct()
    {
        float timer = Random.Range(0, destructionDelay);
        Invoke("Boom", timer);
    }

    public void Boom()
    {
        GetComponent<Explosion>().BlowUp();
    }

    void Update() {
        myT.Rotate(rand_rotation * Time.deltaTime);
    }
}
