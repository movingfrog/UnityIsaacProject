using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public GameObject Bomb;
    Animator ani;
    GameObject childH;
    GameObject childI;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        childH = transform.GetChild(0).gameObject;
        childI = transform.GetChild(1).gameObject;
    }

    void OnUseBomb()
    {
        Debug.Log(PickUp.Bomb);
        if(PickUp.Bomb > 0)
        {
            Instantiate(Bomb, transform.position, Quaternion.identity);
            PickUp.Bomb--;
        }
    }

    public void ItemUp(Sprite sp)
    {
        childH.SetActive(!childH.activeSelf);
        childI.SetActive(!childI.activeSelf);
        ani.SetTrigger("isGetItem");
        childI.GetComponent<SpriteRenderer>().sprite = sp;
        Itemup(3);
    }

    public IEnumerator Itemup(float time)
    {
        yield return new WaitForSeconds(time);
        childH.SetActive(!childH.activeSelf);
        childI.SetActive(!childI.activeSelf);
    }
}
