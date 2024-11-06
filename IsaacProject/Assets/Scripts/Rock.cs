using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject rockPicec;
    public int CloneNum;

    public void Breakable()
    {
        Destroy(gameObject);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < CloneNum; i++)
            {
                GameObject Clone = Instantiate(rockPicec, transform);
                Clone.transform.localScale = new Vector3(0.5f - i * 0.2f, 0.5f - i * 0.2f, 1);
                Clone.transform.SetParent(this.gameObject.GetComponentInParent<Transform>());
            }
        }
    }

    private void OnDestroy()
    {
        for(int i = 0;i<3;i++)
        {
            GameObject Clone = Instantiate(rockPicec, transform);
            Clone.transform.localScale = new Vector3(0.5f - i * 0.2f, 0.5f - i * 0.2f, 1);
            Clone.transform.SetParent(gameObject.GetComponentInParent<Transform>());
        }
    }
}
