public class ProjectileController : WeaponController
{
    protected override void Start()
    {
        base.Start();;
    }

    protected override void Attack()
    {
        base.Attack();
        var spawnedArrow = Instantiate(WeaponData.Prefab);
        spawnedArrow.transform.position = transform.position; 
        spawnedArrow.GetComponent<ProjectileBehaviour>().DirectionChecker(PlayerMovement.LastMovedVector);
    }
}
