using UnityEngine;
using UnityEngine.InputSystem;

public class Isaac_Controller : Isaac_Stat
{
    Rigidbody2D rb;
    Animator ani;

    Isaac_Attack child;

    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        child = transform.GetChild(0).GetComponent<Isaac_Attack>();
        Debug.Log(child);
    }

    private void FixedUpdate()
    {
        bool isControl = (moveDirection != Vector2.zero);
        if (isControl)
        {
            rb.velocity += moveDirection * Speed;
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        if (input != null)
        {
            moveDirection = new Vector2(input.x, input.y);
            
            if (input.x == 0 && input.y == 0)
            {
                ani.SetFloat("InputX", 0);
                ani.SetFloat("InputY", 0);
            }
            else if (input.y != 0)
            {
                ani.SetFloat("InputY", input.y);
            }
            else if (input.x != 0)
            {
                if (input.x > 0)
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                else if (input.x < 0)
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                ani.SetFloat("InputX", input.x);
            }
            child.Move(input);
        }
    }
}