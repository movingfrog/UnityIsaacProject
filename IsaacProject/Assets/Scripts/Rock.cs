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
                GameObject Clone = Instantiate(rockPicec);
                Clone.transform.localScale = new Vector3(0.7f - i * 0.1f, 0.7f - i * 0.1f, 1);
            }
        }
    }

    private void OnDestroy()
    {
        for(int i = 0;i<3;i++)
        {
            GameObject Clone = Instantiate(rockPicec);
            Clone.transform.localScale = new Vector3(0.7f - i * 0.1f, 0.7f - i * 0.1f, 1);
        }
    }
}
