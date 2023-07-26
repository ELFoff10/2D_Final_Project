using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private DynamicJoystick _dynamicJoystick;

	public float LastHorizontalVector { get; private set; }
	public float LastVerticalVector { get; private set; }
	public Vector2 MoveDir { get; private set; }
	public Vector2 LastMovedVector { get; private set; }

	private Rigidbody2D _rigidbody2D;
	private PlayerStats _player;

	private void Start()
	{
		_player = GetComponent<PlayerStats>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
		LastMovedVector = new Vector2(1, 0f);
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
		if (GameManager.Instance.IsGameOver)
		{
			return;
		}

		var moveX = _dynamicJoystick.Horizontal;
		var moveY = _dynamicJoystick.Vertical;

		MoveDir = new Vector2(moveX, moveY).normalized;

		if (MoveDir.x != 0)
		{
			LastHorizontalVector = MoveDir.x;
			LastMovedVector = new Vector2(LastHorizontalVector, 0f);
		}

		if (MoveDir.y != 0)
		{
			LastVerticalVector = MoveDir.y;
			LastMovedVector = new Vector2(0f, LastVerticalVector);
		}

		if (MoveDir.x != 0 && MoveDir.y != 0)
		{
			LastMovedVector = new Vector2(LastHorizontalVector, LastVerticalVector);
		}
	}

	private void Move()
	{
		if (GameManager.Instance.IsGameOver)
		{
			return;
		}

		_rigidbody2D.velocity =
			new Vector2(MoveDir.x * _player.CurrentMoveSpeed, MoveDir.y * _player.CurrentMoveSpeed);
	}
}