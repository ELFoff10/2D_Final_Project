using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform target;

    private void Update()
    {
        var position = target.position;
        mainCamera.transform.position = new Vector3(position.x, position.y, -10);
    }
}
