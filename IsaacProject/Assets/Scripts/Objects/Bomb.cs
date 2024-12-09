using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float boomTimeX5 = 0.25f;
    public GameObject child;
    public ParticleSystem particle;

    private void Awake()
    {
        StartCoroutine(Boom());
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }

    IEnumerator Boom()
    {
        child.SetActive(true);

        child.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.55f);
        gameObject.transform.localScale = new Vector3(1.2f, 1.0f, 1.0f);
        yield return new WaitForSeconds(boomTimeX5);
        child.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.55f);
        gameObject.transform.localScale = new Vector3(1.0f,1.2f, 1.0f);
        yield return new WaitForSeconds(boomTimeX5);
        child.GetComponent<SpriteRenderer>().color = new Color(1, 0.92f, 0.016f, 0.55f);
        gameObject.transform.localScale = new Vector3(1.2f, 1.0f, 1.0f);
        yield return new WaitForSeconds(boomTimeX5);
        child.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.55f);
        gameObject.transform.localScale = new Vector3(1.0f,1.2f, 1.0f);
        yield return new WaitForSeconds(boomTimeX5);
        child.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.55f);
        gameObject.transform.localScale = new Vector3(1.2f, 1.0f, 1.0f);
        yield return new WaitForSeconds(boomTimeX5);
        KaBoom();
        Destroy(gameObject, 0.65f);
    }

    public void KaBoom()
    {
        particle.gameObject.SetActive(true);
        Collider2D[] collider = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.8f,1.8f), 0);
        foreach(Collider2D colliders in collider)
        {
            if (colliders.CompareTag("Wall"))
            {
                Destroy(colliders.gameObject);
            }
            if (colliders.CompareTag("Player"))
            {
                if (Isaac_Health.Health > 0)
                    Isaac_Health.Health -= 2;
                else
                    Isaac_Health.redHealth -= 2;
                Debug.Log(Isaac_Health.Health);
                Debug.Log(Isaac_Health.redHealth);
            }
        }
    }
}
