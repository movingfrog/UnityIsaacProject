using UnityEngine;

public class Tear : Isaac_Stat
{
    public static bool isWallPenet;
    public static bool isEnemyPenet;

    Vector2 vecUper;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + vecUper * ShotSpeed * 4.0f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Enemy"))
        {
            if (!isWallPenet || !isEnemyPenet)
                Destroy(gameObject);
        }
    }

    public void HO(Vector2 input, Vector2 velocity)
    {
        vecUper = input + velocity;
    }
}