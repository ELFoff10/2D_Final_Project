using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
	[SerializeField]
	private float _pullSpeed;
	private PlayerStats _player;
	private CircleCollider2D _playerCollector;

	private void Start()
	{
		_player = FindObjectOfType<PlayerStats>();
		_playerCollector = GetComponent<CircleCollider2D>();
	}

	private void Update()
	{
		_playerCollector.radius = _player.CurrentMagnet;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.gameObject.TryGetComponent(out ICollectible collectible)) return;

		var component = other.gameObject.GetComponent<Rigidbody2D>();
		Vector2 forceDirection = (transform.position - other.transform.position).normalized;
		component.AddForce(forceDirection * _pullSpeed);

		collectible.Collect();
	}
}