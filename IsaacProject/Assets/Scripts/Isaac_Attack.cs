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
                FireTear(input); // �ѹ� ����
                isShooting = true;
                isHoldShooting = true; // �� ���� ����
                StartCoroutine(GenerateTear(input)); // �� ������ ���� ����
            }
        }
        else
        {
            isHoldShooting = false; // ���� ����
        }
        Debug.Log(colTime);
    }

    IEnumerator GenerateTear(Vector2 input)
    {
        while (isHoldShooting)
        {
            if (colTime >= compareColTime) // ��Ÿ�� üũ
            {
                FireTear(input); // ��Ÿ�ӿ� ���� ����
                colTime = 0.0f;
            }
            yield return new WaitForSeconds(compareColTime); // ��Ÿ�� ��ٸ�
        }
        isShooting = false; // ���� ����
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
            colTime += Time.deltaTime; // ��Ÿ�� ����
        }

        if (Keyboard.current.anyKey.wasReleasedThisFrame)
        {
            isHoldShooting = false; // Ű�� �������� �� ���� ����
        }
    }
}