using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBomb : PickUp
{
    public GameObject child;

    protected override void PickUpItem()
    {
        base.PickUpItem();
        child.SetActive(true);
    }
    protected override void OnDestroy()
    {
        Bomb++;
    }
}
