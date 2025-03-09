using UnityEngine;

public class Isaac_Stat : MonoBehaviour
{
    private static Isaac_Stat instance;
    public static Isaac_Stat Instance
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

    public float Speed = 1.0f;
    public float Tears = 2.73f;
    public float TearUper;
    public const float minTears = 0.01f;
    public float defaultMaxTears = 5.0f;
    public float maxTears
    {
        get
        {
            return 120f;
        }
    }
    public float Damage = 3.5f;
    public float Range = 6.5f;
    public float ShotSpeed = 1.0f;
    public const float minShotSpeed = 0.6f;
    public float Luck = 0.0f;

    private void Awake()
    {
        if(Instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("DonDestroyOnLoad");
        }
        else
        {
            Debug.Log("DIE");
            Destroy(gameObject);
        }
    }

    public void ResetAttackRate()
    {
        Isaac_Attack.compareColTime = maxTears / (Tears + TearUper) * 0.02f;
    }

    public void HeathUP()
    {
        Isaac_Health.maxRedHealth += 2;
        Isaac_Health.redHealth += 2;
    }
    public void speedUP(float s)
    {
        Speed += s / Speed;
        if (Speed > 2)
            Speed = 2;
    }
    public void tearsUP(float t)
    {
        if(Tears + TearUper < defaultMaxTears)
        {
            TearUper += t / Tears + TearUper;
            if(Tears + TearUper > defaultMaxTears)
            {
                TearUper = 5 - 2.73f;
            }
            ResetAttackRate();
        }
    }
    public void maxTearUP(float t)
    {
        defaultMaxTears += 0.5f;
        tearsUP(t);
    }
    public void damageUP(float d)
    {
        Damage += d / Damage;
    }
    public void rangeUP(float r)
    {
        Range += r;
    }
    public void SSpeedDown(float S)
    {
        if(ShotSpeed > minShotSpeed)
        {
            ShotSpeed -= S / 10;
        }
        if(ShotSpeed < minShotSpeed)
            ShotSpeed = minShotSpeed;
    }
    public void SSpeedUP(float S)
    {
        ShotSpeed += S / 10;
    }
    public void LuckUP()
    {
        Luck += 1;
    }
}