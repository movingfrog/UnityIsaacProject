using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBomb : PickUp
{
    SpriteRenderer render;
    public GameObject child;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

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
