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
		
		AudioManager.Instance.EventInstances[5].start();

		var player = FindObjectOfType<PlayerStats>();
		player.ReduceHealth(HealthToReduce);
	}
}