using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    [HideInInspector] 
    public float lastHorizontalVector;
    [HideInInspector] 
    public float lastVerticalVector;
    [HideInInspector] 
    public Vector2 moveDir;
    [HideInInspector] 
    public Vector2 lastMovedVector;
    
    // References
    private Rigidbody2D _rigidbody2D;
    private PlayerStats _player;

    private void Start()
    {
        _player = GetComponent<PlayerStats>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f); // If we don't this and game starts up and the player doesn't move, the projectile weapon will have no momemtum
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

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f); // Last moved X
        }

        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector); // Last moved Y
        }

        if (moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(moveDir.x * _player._currentMoveSpeed, moveDir.y * _player._currentMoveSpeed);
    }
}
