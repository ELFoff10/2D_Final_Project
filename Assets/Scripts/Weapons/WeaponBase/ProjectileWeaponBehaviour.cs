using UnityEngine;

/// <summary>
/// Base script of all projectile behaviours [To be placed on a prefab of a weapon that is a projectile]
/// </summary>
public class ProjectileWeaponBehaviour : MonoBehaviour
{
	[SerializeField]
	private float _destroyAfterSeconds;
	public WeaponScriptableObject WeaponData;

	protected Vector3 Direction;

	protected float CurrentDamage;
	protected float CurrentSpeed;
	protected float CurrentCooldownDuration;
	protected int CurrentPierce;

	private void Awake()
	{
		CurrentDamage = WeaponData.Damage;
		CurrentSpeed = WeaponData.Speed;
		CurrentCooldownDuration = WeaponData.CooldownDuration;
		CurrentPierce = WeaponData.Pierce;
	}

	protected virtual void Start()
	{
		Destroy(gameObject, _destroyAfterSeconds);
	}

	protected virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			var enemy = other.GetComponent<EnemyStats>();
			enemy.TakeDamage(GetCurrentDamage());
			ReducePierce();
		}
		else if (other.CompareTag("Prop"))
		{
			if (!other.gameObject.TryGetComponent(out BreakableProps breakable)) return;

			breakable.TakeDamage(GetCurrentDamage());
			ReducePierce();
		}
	}

	public float GetCurrentDamage()
	{
		return CurrentDamage *= FindObjectOfType<PlayerStats>().CurrentMight;
	}

	public void DirectionChecker(Vector3 dir)
	{
		Direction = dir;

		var dirX = Direction.x;
		var dirY = Direction.y;

		var scale = transform.localScale;
		var rotation = transform.rotation.eulerAngles;

		switch (dirX)
		{
			// left
			case < 0 when dirY == 0:
				scale.x = scale.x * -1;
				scale.y = scale.y * -1;
				break;
			// down
			case 0 when dirY < 0:
				rotation.z = -90f;
				break;
			// up
			case 0 when dirY > 0:
				rotation.z = 90f;
				break;
			// right up
			case > 0 when dirY > 0:
				rotation.z = 45f;
				break;
			// right down
			case > 0 when dirY < 0:
				rotation.z = -45f;
				break;
			// left up
			case < 0 when dirY > 0:
				scale.x = scale.x * -1;
				scale.y = scale.y * -1;
				rotation.z = -45f;
				break;
			// left down
			case < 0 when dirY < 0:
				scale.x = scale.x * -1;
				scale.y = scale.y * -1;
				rotation.z = 45f;
				break;
		}

		transform.localScale = scale;
		transform.rotation = Quaternion.Euler(rotation);
	}

	private void ReducePierce()
	{
		CurrentPierce--;
		if (CurrentPierce <= 0)
		{
			Destroy(gameObject);
		}
	}
}