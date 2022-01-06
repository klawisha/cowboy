using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]GameObject explosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void IveBeenHit(Vector3 pos)
    {
       GameObject go = Instantiate(explosion, pos, Quaternion.identity,transform) as GameObject;
        Destroy(go, 6f);
    }



}
