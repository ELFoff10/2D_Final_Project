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

		var playerStats = FindObjectOfType<PlayerStats>();
		playerStats.IncreaseExperience(ExperienceGranted);
	}
}