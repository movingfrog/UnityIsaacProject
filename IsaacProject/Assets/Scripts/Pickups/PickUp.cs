using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    public static int Penny;
    public static int Bomb;
    public static int Key;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUpItem();
            Destroy(gameObject, 0.3f);
        }
    }

    protected virtual void PickUpItem()
    {
        transform.localScale = new Vector3(3f, 0.2f, 1f);
        Destroy(gameObject.GetComponent<Collider2D>());
    }

    protected abstract void OnDestroy();
}
