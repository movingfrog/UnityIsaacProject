using UnityEngine;

public enum PChest
{
    K = 0,
    B = 1,
    C = 2,
    H = 3,
    Pil = 4,
    I = 5,
}

public class Chest : MonoBehaviour
{
    public Sprite openedChest;
    public GameObject[] Items;
    PChest pChest = new PChest();
    int quantity;
    int Type;
    bool GChest;

    private void Start()
    {
        GChest = gameObject.CompareTag("GChest");
        quantity = GChest ? Random.Range(2, 7) : Random.Range(1, 5);
        Type = Random.Range(1, GChest ? 4 : 3);

    }
    public void SpawnPItem(PChest Type)
    {
        Debug.Log("아이템소환");
        switch (Type)
        {
            case PChest.I:
                Destroy(gameObject.GetComponent<BoxCollider2D>());
                break;
            default:
                //Instantiate(Items[(int)Type]);
                Debug.Log("아이템소환");
                gameObject.layer = 10;
                Destroy(gameObject.GetComponent<BoxCollider2D>());
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GChest)
            {
                if (PickUp.Key <= 0)
                {
                    Debug.Log(PickUp.Key);
                    return;
                }
                PickUp.Key--;
            }
            switch (Type)
            {
                case 1:
                    for (int i = 0; i < quantity; i++)
                    {
                        pChest = (PChest)Random.Range(0, 4);
                        SpawnPItem(pChest);
                        Debug.Log("아이템소환");
                    }
                    break;
                case 2:
                    pChest = PChest.Pil;
                    SpawnPItem(pChest);
                    Debug.Log("아이템소환");
                    break;
                case 3:
                    pChest = PChest.I;
                    SpawnPItem(pChest);
                    Debug.Log("아이템소환");
                    break;
            }
            gameObject.GetComponent<SpriteRenderer>().sprite = openedChest;
        }
    }
}
