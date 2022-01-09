using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUI : MonoBehaviour
{
    
    [SerializeField]RectTransform barRectT;
    float maxWidth;


    void Awake()
    {
         maxWidth = barRectT.rect.width;
    }

    void OnEnable()
    {
        EventManager.onTakeDamage += UpdateShieldUI;
    }

    void OnDisable()
    {
        EventManager.onTakeDamage -= UpdateShieldUI;
    }

    void UpdateShieldUI(float percentage)
    {
        barRectT.sizeDelta = new Vector2(maxWidth * percentage, 10f);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
