using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedSword = Instantiate(weaponData.Prefab);
        spawnedSword.transform.position = transform.position; // Assign the position to be the same as this object which is parented to the player
        spawnedSword.transform.parent = transform; // So that is spawns below this object
    }
}
