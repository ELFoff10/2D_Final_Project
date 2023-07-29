using UnityEngine;

public class ProjectileBehaviour : ProjectileWeaponBehaviour
{
	protected override void Start()
	{
		base.Start();
	}

	private void Update()
	{
		transform.position += Direction * (CurrentSpeed * Time.deltaTime);
	}
}