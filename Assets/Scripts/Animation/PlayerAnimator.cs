using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
	private Animator _animator;
	private PlayerMovement _playerMovement;
	private SpriteRenderer _spriteRenderer;
	private static readonly int Move = Animator.StringToHash("Move");
	private static readonly int MoveUp = Animator.StringToHash("MoveUp");
	private static readonly int MoveDown = Animator.StringToHash("MoveDown");
	private static readonly int Idle = Animator.StringToHash("Idle");

	private void Start()
	{
		_animator = GetComponent<Animator>();
		_playerMovement = GetComponent<PlayerMovement>();
		_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}

	private void Update()
	{
		MoveAnimation();
		SpriteFlipX();
	}

	private void MoveAnimation()
	{
		if (_playerMovement.MoveDir.x != 0 || _playerMovement.MoveDir.y != 0)
		{
			_animator.SetBool(Move, true);
		}
		// if (_playerMovement.MoveDir.x is > -0.5f and < 0.5f && _playerMovement.MoveDir.y > 0)
		// {
		// 	_animator.SetBool(MoveUp, true);
		// }
		// if (_playerMovement.MoveDir.x is > -0.5f and < 0.5f && _playerMovement.MoveDir.y < 0)
		// {
		// 	_animator.SetBool(MoveDown, true);
		// }
	}

	private void SpriteFlipX()
	{
		_spriteRenderer.flipX = _playerMovement.MoveDir.x > 0;
	}
}