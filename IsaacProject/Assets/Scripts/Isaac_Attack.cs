using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Isaac_Attack : Isaac_Stat
{
    public GameObject Tear;

    private float uperTime = 0;
    private float compareColTime;

    Animator ani;

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
                ani.SetBool("isAttack", true);
                ani.SetTrigger("isattack");
                ani.SetFloat("InputY", 1);
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                TearSpawn(Vector2.down);
                ani.SetBool("isAttack", true);
                ani.SetTrigger("isattack");
                ani.SetFloat("InputY", -1);
            }
            else if(Input.GetKey(KeyCode.LeftArrow))
            {
                TearSpawn(Vector2.left);
                ani.SetTrigger("isattack");
                ani.SetBool("isAttack", true);
                ani.SetFloat("InputX", -1);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                TearSpawn(Vector2.right);
                ani.SetBool("isAttack", true);
                ani.SetTrigger("isattack");
                ani.SetFloat("InputX", 1);
            }
            else
            {
                ani.SetBool("isAttack", false);
                ani.SetFloat("InputX", 0);
                ani.SetFloat("InputY", 0);
            }
        }
        else
        {
            uperTime += Time.deltaTime;
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