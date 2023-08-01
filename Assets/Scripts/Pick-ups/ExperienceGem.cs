public class ExperienceGem : Pickup
{
	public int ExperienceGranted;

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

		AudioManager.Instance.EventInstances[(int)AudioNameEnum.PickUpGem].start();

		var playerStats = FindObjectOfType<PlayerStats>();
		playerStats.IncreaseExperience(ExperienceGranted);
	}
}