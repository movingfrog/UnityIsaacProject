using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class RockPiece : MonoBehaviour
{
    public float xForce;
    public float yForce;
    public float gravity;
    public float speed;
    private float XForce;
    private float YForce;

    public float time;

    Rigidbody2D rb;

    private void Awake()
    {
        XForce = Random.Range(-xForce, xForce);
        YForce = Random.Range(-yForce, yForce);
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Boom());
    }

    IEnumerator Boom()
    {
        rb.AddForce(new Vector2(XForce, YForce) * speed);
        yield return new WaitForSeconds(time);
        rb.velocity = Vector2.zero;
        rb.AddForce(-Vector2.up * gravity * speed * 0.5f);
        while(gameObject.GetComponent<SpriteRenderer>().color != new Color(0.4706f, 0.4706f, 0.4706f))
        {
            Color sprite = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(sprite.r - 0.05294f, sprite.g - 0.05294f, sprite.b - 0.05294f);
            yield return new WaitForSeconds(time * 0.1f);
        }
        rb.velocity = Vector2.zero;
        Debug.Log("adfs");
    }
}
