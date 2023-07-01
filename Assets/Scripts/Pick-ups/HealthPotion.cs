using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Pickup, ICollectible
{
    public int healthToRestore;
    public void Collect()
    {
        var player = FindObjectOfType<PlayerStats>();
        player.RestoreHealth(healthToRestore);
    }
}
