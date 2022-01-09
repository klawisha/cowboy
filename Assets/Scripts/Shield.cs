using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]int maxHealth = 10;
    [SerializeField]int curHealth;
    [SerializeField]float regenRate = 2f;
    [SerializeField]int regenAmount = 1;

    void Start()
    {
        curHealth = maxHealth;

        InvokeRepeating("Regenerate", regenRate, regenRate);
    }

    void Regenerate()
    {
        if(curHealth < maxHealth)
            curHealth += regenAmount;

        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
            //CancelInvoke();
        }

        EventManager.TakeDamage(curHealth/(float)maxHealth);
    }

        public void TakeDamage(int damage = 1)
        {
            curHealth -= damage;
            
            if(curHealth < 0)
                curHealth = 0;

            EventManager.TakeDamage(curHealth/(float)maxHealth);

            if(curHealth < 1)
            {
                GetComponent<Explosion>().BlowUp();
                EventManager.PlayerDeath();
            }    //dead

        }

    void Update()
    {
        
    }
}
