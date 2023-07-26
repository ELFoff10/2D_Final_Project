using UnityEngine;

public class ArrowBehaviour : ProjectileWeaponBehaviour
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