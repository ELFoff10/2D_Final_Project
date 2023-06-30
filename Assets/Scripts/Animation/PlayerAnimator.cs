using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private SpriteRenderer _spriteRenderer;
    private static readonly int Move = Animator.StringToHash("Move");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        MoveAnimation();
        SpriteFlipX();
    }

    private void MoveAnimation()
    {
        if (_playerMovement.moveDir.x != 0 || _playerMovement.moveDir.y != 0)
        {
            _animator.SetBool(Move, true);
        }
        else
        {
            _animator.SetBool(Move, false);
        }
    }

    private void SpriteFlipX()
    {
        _spriteRenderer.flipX = _playerMovement.moveDir.x > 0;
    }
}