using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private SpriteRenderer _spriteRenderer;
    private static readonly int MoveUp = Animator.StringToHash("MoveUp");
    private static readonly int MoveDown = Animator.StringToHash("MoveDown");
    private static readonly int MoveSide = Animator.StringToHash("MoveSide");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MoveAnimation();
    }

    private void MoveAnimation()
    {
        SpriteDirection();

        switch (_playerMovement.moveDirection.x)
        {
            case > 0:
                _animator.SetBool(MoveSide, true);
                break;
            case < 0:
                _animator.SetBool(MoveSide, true);
                break;
            default:
                _animator.SetBool(MoveSide, false);
                break;
        }

        switch (_playerMovement.moveDirection.y)
        {
            case > 0:
                _animator.SetBool(MoveUp, true);
                break;
            case < 0:
                _animator.SetBool(MoveDown, true);
                break;
            default:
                _animator.SetBool(MoveUp, false);
                _animator.SetBool(MoveDown, false);
                break;
        }
    }

    private void SpriteDirection()
    {
        _spriteRenderer.flipX = _playerMovement.lastHorizontalVector > 0;
    }
}