using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPill : PickUp
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUpItem();
            collision.GetComponent<UseItem>().ItemUp(gameObject.GetComponent<SpriteRenderer>().sprite);
            Destroy(gameObject, 0.3f);
        }
    }

    protected override void OnDestroy()
    {
        
    }
}
