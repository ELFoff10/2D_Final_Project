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

		var player = FindObjectOfType<PlayerStats>();
		player.RestoreHealth(HealthToRestore);
	}
}