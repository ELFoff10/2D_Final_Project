using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [HideInInspector] public float lastHorizontalVector;
    [HideInInspector] public Vector2 moveDirection;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        InputManagement();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void InputManagement()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (moveDirection.x != 0)
        {
            lastHorizontalVector = moveDirection.x;
        }
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
