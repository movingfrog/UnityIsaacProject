using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isaac_Health : MonoBehaviour
{
    public static int Health;
    public static int redHealth;

    public static int maxRedHealth;
    public const int maxHealth = 24;

    private void Start()
    {
        redHealth = 6;
        maxRedHealth = redHealth;
        Health = 0;
    }

    private void LateUpdate()
    {
        redHealth = redHealth > maxHealth ? maxRedHealth : redHealth;
        Health = Health < 0 ? 0 : Health;
        if(Health + redHealth == 0)
        {
            Debug.Log("You are die");
        }
    }
}
