using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private SpriteRenderer _spriteRenderer;
    private static readonly int Move = Animator.StringToHash("Move");
    private static readonly int MoveUp = Animator.StringToHash("MoveUp");
    private static readonly int MoveDown = Animator.StringToHash("MoveDown");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        MoveAnimation();
        SpriteFlipX();
    }

    private void MoveAnimation()
    {
        // if (_playerMovement.MoveDir.x != 0 || _playerMovement.MoveDir.y != 0)
        // {
        //     _animator.SetBool(Move, true);
        // }
        // else
        // {
        //     _animator.SetBool(Move, false);
        // }
        //
        // if (_playerMovement.MoveDir.x is < 0.3f and > -0.3f && _playerMovement.MoveDir.y > 0) 
        // {
        //     _animator.SetBool(MoveUp, true);
        // }
        // else
        // {
        //     _animator.SetBool(MoveUp, false);
        // }
        //
        // if (_playerMovement.MoveDir.x is < 0.3f and > -0.3f && _playerMovement.MoveDir.y < 0) 
        // {
        //     _animator.SetBool(MoveDown, true);
        // }
        // else
        // {
        //     _animator.SetBool(MoveDown, false);
        // }
    }

    private void SpriteFlipX()
    {
        _spriteRenderer.flipX = _playerMovement.MoveDir.x > 0;
    }
}