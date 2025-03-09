using System.Collections;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public GameObject Bomb;
    Animator ani;
    GameObject childH;
    GameObject childI;
    GameObject Item;

    int pillnum;

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

    void OnUsePill()
    {
        if(Item != null)
        {
            Item = null;
            switch (PillManager.Instance.pillEffects[pillnum])
            {
                case PillManager.PillEffect.ShotSpeedUp:
                    Isaac_Stat.Instance.SSpeedUP(1.5f);
                    break;
                case PillManager.PillEffect.HealthUp:
                    Isaac_Stat.Instance.HeathUP();
                    break;
                case PillManager.PillEffect.RangeUp:
                    Isaac_Stat.Instance.rangeUP(2.5f);
                    break;
                case PillManager.PillEffect.TearsUp:
                    Isaac_Stat.Instance.tearsUP(0.35f);
                    break;
                case PillManager.PillEffect.LuckUp:
                    Isaac_Stat.Instance.LuckUP();
                    break;
                case PillManager.PillEffect.SpeedUp:
                    Isaac_Stat.Instance.speedUP(0.15f);
                    break;
                case PillManager.PillEffect.ShotSpeedDown:
                    Isaac_Stat.Instance.SSpeedDown(1.5f);
                    break;
            }
            PillManager.Instance.Names[pillnum] = true;
            UIManager.Instance.PillEffect.gameObject.SetActive(false);
            UIManager.Instance.Pill.gameObject.SetActive(false);
        }
    }

    public void ItemUp(Sprite sp, float T)
    {
        childH.SetActive(false);
        childI.SetActive(true);
        ani.SetTrigger("isGetItem");
        ani.SetBool("isget", true);
        childI.GetComponent<SpriteRenderer>().sprite = sp;
        gameObject.tag = "getItem";
        StartCoroutine(Itemup(T));
    }
    public void changeItem(GameObject item)
    {
        if(Item != null)
        {
            Instantiate(Item, transform.position, Quaternion.identity);
        }
        Debug.Log(item);
        for(int i = 0; i < PillManager.Instance.pills.Length; i++)
        {
            if(item.GetComponent<SpriteRenderer>().sprite == PillManager.Instance.pills[i].GetComponent<SpriteRenderer>().sprite)
            {
                pillnum = i;
                Item = PillManager.Instance.pills[i];
                Debug.Log(pillnum);
                break;
            }
        }
        if (PillManager.Instance.Names[pillnum])
        {
            UIManager.Instance.PillEffect.text = PillManager.Instance.pillEffects[pillnum].ToString();
        }
        else
        {
            UIManager.Instance.PillEffect.text = "???";
        }
        UIManager.Instance.PillEffect.gameObject.SetActive(true);
        UIManager.Instance.Pill.gameObject.SetActive(true);
        UIManager.Instance.Pill.sprite = Item.GetComponent<SpriteRenderer>().sprite;
        Debug.Log(PillManager.Instance.pillEffects[pillnum].ToString());
    }

    public IEnumerator Itemup(float time)
    {
        yield return new WaitForSeconds(time);
        childH.SetActive(true);
        childI.SetActive(false);
        ani.SetBool("isget", false);
        gameObject.tag = "Player";
    }
}
