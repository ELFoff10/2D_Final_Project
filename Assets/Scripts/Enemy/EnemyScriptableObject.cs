using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
	[SerializeField]
	private float _moveSpeed;
	public float MoveSpeed
	{
		get => _moveSpeed;
		private set => _moveSpeed = value;
	}

	[SerializeField]
	private float _maxHealth;
	public float MaxHealth
	{
		get => _maxHealth;
		private set => _maxHealth = value;
	}

	[SerializeField]
	private float _damage;
	public float Damage
	{
		get => _damage;
		private set => _damage = value;
	}
}