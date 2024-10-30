using System.Collections;
using System.Collections.Generic;
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

    IEnumerator Boom()
    {
        child.SetActive(true);

        child.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(boomTimeX5);
        child.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(boomTimeX5);
        child.GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(boomTimeX5);
        child.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(boomTimeX5);
        child.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(boomTimeX5);
        kaBoom(Quaternion.identity);
        Destroy(gameObject, 1.25f);
    }

    public void kaBoom(Quaternion quaternion)
    {
        particle.gameObject.SetActive(true);
        Collider2D[] collider = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.8f,1.8f), 0);
        foreach(Collider2D colliders in collider)
        {
            if (colliders.CompareTag("Wall"))
            {
                Debug.Log("돌이 깨졌습니다");
            }
            Debug.Log("100DMG");
        }
    }
}
