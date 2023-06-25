using UnityEngine;

public class JoystickPlayer : MonoBehaviour
{
    [SerializeField] private FixedJoystick dynamicJoystick;
    
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void FixedUpdate()
    {
        _playerMovement.moveDirection.x = dynamicJoystick.Horizontal;
        _playerMovement.moveDirection.y = dynamicJoystick.Vertical;
    }
}