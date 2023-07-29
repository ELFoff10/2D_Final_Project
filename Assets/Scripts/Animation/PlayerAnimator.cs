using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
	private Animator _animator;
	private PlayerMovement _playerMovement;
	private SpriteRenderer _spriteRenderer;
	private static readonly int MoveSide = Animator.StringToHash("MoveSide");
	// private static readonly int MoveUp = Animator.StringToHash("MoveUp");
	// private static readonly int MoveDown = Animator.StringToHash("MoveDown");
	// private static readonly int Idle = Animator.StringToHash("Idle");

	private void Start()
	{
		_animator = GetComponent<Animator>();
		_playerMovement = GetComponent<PlayerMovement>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
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
			_animator.SetBool(MoveSide, true);
		}
		else
		{
			_animator.SetBool(MoveSide, false);
		}
	}

	private void SpriteFlipX()
	{
		_spriteRenderer.flipX = _playerMovement.MoveDir.x > 0;
	}
}