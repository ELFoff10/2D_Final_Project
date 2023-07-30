public class ProjectileController : WeaponController
{
    protected override void Start()
    {
        base.Start();;
    }

    protected override void Attack()
    {
        base.Attack();
        if (WeaponData.PrefabGun != null)
        {
            var spawnGun = Instantiate(WeaponData.PrefabGun);
            spawnGun.transform.position = transform.position;
            spawnGun.GetComponent<ProjectileBehaviour>().DirectionChecker(PlayerMovement.LastMovedVector);
        }
        
        var spawnedProjectile = Instantiate(WeaponData.Prefab);
        spawnedProjectile.transform.position = transform.position; 
        spawnedProjectile.GetComponent<ProjectileBehaviour>().DirectionChecker(PlayerMovement.LastMovedVector);
    }
}
