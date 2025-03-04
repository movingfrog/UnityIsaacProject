using UnityEngine;

public class Isaac_Attack : Isaac_Stat
{
    [Header("Tear")]
    public GameObject Tear;

    private float uperTime = 0;
    private float compareColTime;

    Animator ani;

    [Header("MoveAni")]
    public Sprite[] sprite = new Sprite[4];

    private void Awake()
    {
        ani = GetComponent<Animator>();
        compareColTime = maxTears / (Tears + TearUper) * 0.02f;
    }

    private void Update()
    {
        if(uperTime >= compareColTime)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                TearSpawn(Vector2.up);
                ani.SetFloat("InputY", 1);
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                TearSpawn(Vector2.down);
                ani.SetFloat("InputY", -1);
            }
            else if(Input.GetKey(KeyCode.LeftArrow))
            {
                TearSpawn(Vector2.left);
                ani.SetFloat("InputX", -1);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                TearSpawn(Vector2.right);
                ani.SetFloat("InputX", 1);
            }
            else
            {
                ani.SetFloat("InputX", 0);
                ani.SetFloat("InputY", 0);
            }
        }
        else
        {
            uperTime += Time.deltaTime;
        }
    }

    public void Move(Vector2 vec)
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        ani.enabled = false;
        if(vec.y < 0 || (vec.y == 0 && vec.x == 0))
        {
            sp.sprite = sprite[0];
            ani.enabled = true;
        }
        else if(vec.y > 0)
        {
            sp.sprite = sprite[1];
        }
        else if(vec.x < 0)
        {
            sp.sprite = sprite[2];
        }
        else if(vec.x > 0)
        {
            sp.sprite = sprite[3];
        }
    }

    public void TearSpawn(Vector2 vec)
    {
        uperTime = 0;
        GameObject clone = Instantiate(Tear, transform.position + new Vector3(vec.x, vec.y, 0), new Quaternion(0,0,0,0));
        Tear tear = clone.GetComponent<Tear>();
        tear.HO(vec, Vector2.zero);
        Destroy(clone, Range / 4);
    }
}