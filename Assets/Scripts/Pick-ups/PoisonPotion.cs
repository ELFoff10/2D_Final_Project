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
		
		AudioManager.Instance.EventInstances[(int)AudioNameEnum.PickUpBottle].start();

		var player = FindObjectOfType<PlayerStats>();
		player.ReduceHealth(HealthToReduce);
	}
}