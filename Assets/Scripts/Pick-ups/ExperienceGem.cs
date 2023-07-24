public class ExperienceGem : Pickup, ICollectible
{
    public int ExperienceGranted;
    
    public void Collect()
    {
        var playerStats = FindObjectOfType<PlayerStats>();
        playerStats.IncreaseExperience(ExperienceGranted);
    }
}
