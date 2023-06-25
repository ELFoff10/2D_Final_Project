using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private float cameraOffsetZ; 

    private void FixedUpdate()
    {
        var position = target.position;
        camera.transform.position = new Vector3(position.x, position.y, cameraOffsetZ);
    }
}
