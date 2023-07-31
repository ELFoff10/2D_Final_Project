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
		
		AudioManager.Instance.EventInstances[5].start();

		var player = FindObjectOfType<PlayerStats>();
		player.RestoreHealth(HealthToRestore);
	}
}