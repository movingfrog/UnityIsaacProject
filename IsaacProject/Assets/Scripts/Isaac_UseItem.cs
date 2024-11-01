using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public GameObject Bomb;

    void OnUseBomb()
    {
        Debug.Log(PickUp.Bomb);
        if(PickUp.Bomb > 0)
        {
            Instantiate(Bomb, transform.position, Quaternion.identity);
            PickUp.Bomb--;
        }
    }
}
