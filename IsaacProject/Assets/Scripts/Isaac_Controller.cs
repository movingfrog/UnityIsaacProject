using UnityEngine;
using UnityEngine.InputSystem;

public class Isaac_Controller : Isaac_Stat
{
    Rigidbody2D rb;

    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        bool isControl = (moveDirection != Vector2.zero);
        if (isControl)
        {
            rb.MovePosition(rb.position + moveDirection * Time.deltaTime * Speed * 5.0f);
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        if (input != null)
        {
            moveDirection = new Vector2(input.x, input.y);
        }
    }
}