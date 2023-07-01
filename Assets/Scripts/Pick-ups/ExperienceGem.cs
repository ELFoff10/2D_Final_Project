using UnityEngine;

public class ExperienceGem : Pickup, ICollectible
{
    public int experienceGranted;
    
    public void Collect()
    {
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        playerStats.IncreaseExperience(experienceGranted);
    }
}
