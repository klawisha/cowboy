using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[DisallowMultipleComponent]
[RequireComponent(typeof(Explosion))]
public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]GameObject explosion;
    [SerializeField]Rigidbody rb;
    [SerializeField]float laserHitModifier = 1f;
    [SerializeField]Shield shield;
    [SerializeField]GameObject blowup;


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

        if(shield == null)
        return;

        shield.TakeDamage();


    }

    void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint c in collision.contacts)
            IveBeenHit(c.point);
    }

    public void AddForce(Vector3 pos, Transform source)
    {
        if(rb == null)
        {
            return;
        }
        Vector3 dir = (source.position - pos).normalized;
        rb.AddForceAtPosition(dir.normalized * laserHitModifier, pos, ForceMode.Impulse);
    }


   public void BlowUp()
    {
        GameObject temp = Instantiate(blowup, transform.position, Quaternion.identity) as GameObject;

        Destroy(temp, 3f);

        Destroy(gameObject);
    }



}
