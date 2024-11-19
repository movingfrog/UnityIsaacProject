using UnityEngine;

public enum PChest
{
    K = 0,
    B = 1,
    H = 2,
    C = 3,
    CA = 4,
    Pil = 5,
    T = 6,
    I = 7,
}

public class Chest : MonoBehaviour
{
    public Sprite openedChest;
    public GameObject[] Items;
    public LayerMask layer;
    PChest pChest = new PChest();
    int quantity;
    int Type;
    bool GChest;

    private void Start()
    {
        GChest = gameObject.CompareTag("GChest");
        if (GChest)
            quantity = Random.Range(1, 8);
        else
            quantity = Random.Range(1, 5);
        Type = Random.Range(1, 5);
    }
    public void SpawnPItem(PChest Type)
    {
        switch (Type)
        {
            case PChest.I:
                break;
            default:
                Instantiate(Items[(int)Type]);
                gameObject.layer = layer;
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
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
                    }
                    break;
                case 2:
                    if(Random.Range(0,2) == 1&&GChest)
                        pChest = PChest.CA;
                    else
                        pChest = PChest.Pil;
                    SpawnPItem(pChest);
                    break;
                case 3:
                    pChest = PChest.T;
                    break;
                case 4:
                    if (GChest)
                    {
                        pChest = PChest.I;
                    }
                    break;
            }
        }
    }
}
