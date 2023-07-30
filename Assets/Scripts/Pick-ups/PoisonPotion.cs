public class PoisonPotion : Pickup
{
	public int HealthToReduce;

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
		player.ReduceHealth(HealthToReduce);
	}
}