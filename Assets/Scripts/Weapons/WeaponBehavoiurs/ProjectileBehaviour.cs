using UnityEngine;

public class ProjectileBehaviour : ProjectileWeaponBehaviour
{
	public bool IsMove;

	protected override void Start()
	{
		base.Start();
	}

	private void Update()
	{
		if (IsMove)
		{
			transform.position += Direction * (CurrentSpeed * Time.deltaTime);
		}
	}
}