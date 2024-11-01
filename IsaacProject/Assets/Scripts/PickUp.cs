using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    public static int Penny;
    public static int Bomb;
    public static int Key;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUpItem();
            Destroy(gameObject, 0.2f);
        }
    }

    protected virtual void PickUpItem()
    {
        transform.localScale = new Vector3(3f, 0.2f, 1f);
    }

    protected abstract void OnDestroy();
}
