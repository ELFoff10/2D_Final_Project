using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyStats : MonoBehaviour
{
	public EnemyScriptableObject EnemyData;

	[HideInInspector]
	public float CurrentMoveSpeed;
	[HideInInspector]
	public float CurrentHealth;
	[HideInInspector]
	public float CurrentDamage;

	public float DeSpawnDistance = 20f;
	private Transform _player;

	private void Awake()
	{
		CurrentMoveSpeed = EnemyData.MoveSpeed;
		CurrentHealth = EnemyData.MaxHealth;
		CurrentDamage = EnemyData.Damage;
	}

	private void Start()
	{
		_player = FindObjectOfType<PlayerStats>().transform;
	}

	private void Update()
	{
		if (Vector2.Distance(transform.position, _player.position) >= DeSpawnDistance)
		{
			ReturnEnemy();
		}
	}

	private void OnDestroy()
	{
		var enemySpawner = FindObjectOfType<EnemySpawner>();
		enemySpawner.OnEnemyKilled();
	}

	public void TakeDamage(float damage)
	{
		CurrentHealth -= damage;

		if (CurrentHealth <= 0)
		{
			Kill();
		}
	}

	private void Kill()
	{
		Destroy(gameObject);
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		if (!other.gameObject.CompareTag("Player")) return;

		var player = other.gameObject.GetComponent<PlayerStats>();
		player.TakeDamage(CurrentDamage);
	}

	private void ReturnEnemy()
	{
		var enemySpawner = FindObjectOfType<EnemySpawner>();
		transform.position = _player.position + enemySpawner
			.RelativeSpawnPoints[Random.Range(0, enemySpawner.RelativeSpawnPoints.Count)].position;
	}
}