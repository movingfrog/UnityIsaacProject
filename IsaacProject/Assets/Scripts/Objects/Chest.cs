using UnityEngine;

public enum PChest
{
    K = 0,
    B = 1,
    C = 2,
    H = 3,
    CA = 4,
    Pil = 5,
    T = 6,
    I = 7,
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
        quantity = GChest ? Random.Range(2, 8) : Random.Range(1, 5);
        Type = Random.Range(1, GChest ? 5 : 4);

    }
    public void SpawnPItem(PChest Type)
    {
        Debug.Log("�����ۼ�ȯ");
        switch (Type)
        {
            case PChest.I:
                Destroy(gameObject.GetComponent<BoxCollider2D>());
                break;
            default:
                //Instantiate(Items[(int)Type]);
                Debug.Log("�����ۼ�ȯ");
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
                        Debug.Log("�����ۼ�ȯ");
                    }
                    break;
                case 2:
                    if(Random.Range(0,2) == 1&&GChest)
                        pChest = PChest.CA;
                    else
                        pChest = PChest.Pil;
                    SpawnPItem(pChest);
                    Debug.Log("�����ۼ�ȯ");
                    break;
                case 3:
                    pChest = PChest.T;
                    SpawnPItem(pChest);
                    Debug.Log("�����ۼ�ȯ");
                    break;
                case 4:
                    pChest = PChest.I;
                    SpawnPItem(pChest);
                    Debug.Log("�����ۼ�ȯ");
                    break;
            }
            gameObject.GetComponent<SpriteRenderer>().sprite = openedChest;
        }
    }
}