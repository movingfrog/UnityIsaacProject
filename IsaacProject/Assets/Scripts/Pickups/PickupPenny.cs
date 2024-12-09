using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPenny : PickUp
{
    Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    protected override void PickUpItem()
    {
        ani.SetTrigger("isGet");
    }

    protected override void OnDestroy()
    {
        Penny++;
    }
}
