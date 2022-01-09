using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartGameDelegate();
    public static StartGameDelegate onStartGame;
    public static StartGameDelegate onPlayerDeath;

    public delegate void TakeDamageDelegate(float amt);
    public static TakeDamageDelegate onTakeDamage;


    public static void StartGame()
    {
        if(onStartGame!=null)
            onStartGame();
    }
    public static void TakeDamage(float dmg)
    {
        if(onTakeDamage!=null)
            onTakeDamage(dmg);
    }

    public static void PlayerDeath()
    {
        if(onPlayerDeath != null)
            onPlayerDeath();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
