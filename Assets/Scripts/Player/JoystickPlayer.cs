using UnityEngine;

public class JoystickPlayer : MonoBehaviour
{
    [SerializeField] private FixedJoystick _fixedJoystick;
    
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        _playerMovement.moveDir.x = _fixedJoystick.Horizontal;
        _playerMovement.moveDir.y = _fixedJoystick.Vertical;
    }
}