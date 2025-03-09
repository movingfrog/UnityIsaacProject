using System;
using UnityEngine;

public class PillManager : MonoBehaviour
{
    public enum PillEffect
    {
        SpeedUp,
        TearsUp,
        ShotSpeedUp,
        RangeUp,
        ShotSpeedDown,
        LuckUp,
        HealthUp,
    }

    private static PillManager instance;
    public static PillManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    public GameObject[] pills;
    public PillEffect[] pillEffects = (PillEffect[])Enum.GetValues(typeof(PillEffect));
    public bool[] Names;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Names = new bool[pillEffects.Length];
    }
    private void Start()
    {
        Shuffle(pillEffects);

        foreach(var pill in pills)
        {
            Instantiate(pill);
            Instantiate(pill);
        }
    }

    private void Shuffle(PillEffect[] array)
    {
        System.Random random = new System.Random();
        for(int i = array.Length - 1; i >= 0; i--)
        {
            int j = random.Next(0, i + 1);
            (array[i], array[j]) = (array[j], array[i]); // Swap
        }
    }
}
