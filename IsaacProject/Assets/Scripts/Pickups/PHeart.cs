using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHeart : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && Isaac_Health.maxRedHealth + Isaac_Health.Health < Isaac_Health.maxHealth)
        {
            if (!gameObject.CompareTag("SoulHeart") && Isaac_Health.redHealth >= Isaac_Health.maxRedHealth)
                return;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            transform.localScale = new Vector3(3f, 0.2f, 1f);
            Destroy(gameObject, 0.3f);
        }
    }

    private void OnDestroy()
    {
        switch (gameObject.tag)
        {
            case "RedHeart":
                Isaac_Health.redHealth += 2;
                break;
            case "HalfHeart":
                Isaac_Health.redHealth++;
                break;
            case "SoulHeart":
                Isaac_Health.Health+=2;
                break;
        }
        Debug.Log(Isaac_Health.redHealth);
        Debug.Log(Isaac_Health.Health);
    }
}
