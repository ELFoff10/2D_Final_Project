public class HealthPotion : Pickup, ICollectible
{
    public int HealthToRestore;
    public void Collect()
    {
        var player = FindObjectOfType<PlayerStats>();
        player.RestoreHealth(HealthToRestore);
    }
}
