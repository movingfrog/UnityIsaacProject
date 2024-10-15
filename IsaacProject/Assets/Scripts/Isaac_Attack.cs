using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Isaac_Attack : Isaac_Stat
{
    Rigidbody2D rb;
    Vector2 oldPosition;
    Vector2 currentPostion;
    Vector2 velocity;

    public GameObject TearObject;
    public bool isShooting;
    public bool isHoldShooting;

    public float colTime;
    public float compareColTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        compareColTime = maxTears / (Tears + TearUper) * 0.02f;
        colTime = compareColTime;
        Debug.Log(compareColTime);
    }
    private void Start()
    {
        oldPosition = transform.position;
    }

    void OnAttack(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        if (input.x != 0 || input.y != 0)
        {
            if (!isShooting && colTime >= compareColTime)
            {
                FireTear(input); // 한번 공격
                isShooting = true;
                isHoldShooting = true; // 꾹 누름 상태
                StartCoroutine(GenerateTear(input)); // 꾹 누르면 지속 공격
            }
        }
        else
        {
            isHoldShooting = false; // 공격 중지
        }
        Debug.Log(colTime);
    }

    IEnumerator GenerateTear(Vector2 input)
    {
        while (isHoldShooting)
        {
            if (colTime >= compareColTime) // 쿨타임 체크
            {
                FireTear(input); // 쿨타임에 따라 공격
                colTime = 0.0f;
            }
            yield return new WaitForSeconds(compareColTime); // 쿨타임 기다림
        }
        isShooting = false; // 공격 종료
    }

    void FireTear(Vector2 input)
    {
        GameObject tears_C = Instantiate(TearObject, transform.position + new Vector3(input.x, input.y, 0), Quaternion.Euler(0, 0, 0));
        Tear tear = tears_C.GetComponent<Tear>();
        tear.HO(input, velocity / 10.0f);
        Destroy(tears_C, Range / 2);
    }

    private void Update()
    {
        currentPostion = transform.position;
        var dis = (currentPostion - oldPosition);
        velocity = dis / Time.deltaTime;
        oldPosition = currentPostion;

        if (colTime < compareColTime)
        {
            colTime += Time.deltaTime; // 쿨타임 증가
        }

        if (Keyboard.current.anyKey.wasReleasedThisFrame)
        {
            isHoldShooting = false; // 키가 떼어졌을 때 공격 중지
        }
    }
}