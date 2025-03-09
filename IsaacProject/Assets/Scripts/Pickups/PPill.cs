using UnityEngine;

public class PPill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.localScale = new Vector3(3f, 0.2f, 1f);
            Destroy(gameObject.GetComponent<Collider2D>());
            collision.gameObject.GetComponent<UseItem>().ItemUp(gameObject.GetComponent<SpriteRenderer>().sprite, 0.4f);
            collision.gameObject.GetComponent<UseItem>().changeItem(gameObject);
            Destroy(gameObject, 0.3f);
        }
    }
    private void OnDestroy()
    {
        UIManager.Instance.Pill.gameObject.SetActive(true);
    }
}
