public class HealthPotion : Pickup
{
	public int HealthToRestore;

	public override void Collect()
	{
		if (HasBeenCollected)
		{
			return;
		}
		else
		{
			base.Collect();
		}
		
		AudioManager.Instance.EventInstances[(int)AudioNameEnum.PickUpBottle].start();

		var player = FindObjectOfType<PlayerStats>();
		player.RestoreHealth(HealthToRestore);
	}
}