using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private Camera _mainCamera;
	[SerializeField]
	private Transform _target;

	private void Update()
	{
		var position = _target.position;
		_mainCamera.transform.position = new Vector3(position.x, position.y, -10);
	}
}