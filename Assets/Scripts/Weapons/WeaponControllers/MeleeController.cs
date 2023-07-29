public class MeleeController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }
    
    protected override void Attack()
    {
        base.Attack();
        var spawnedSword = Instantiate(WeaponData.Prefab, transform, true);
        spawnedSword.transform.position = transform.position;
    }
}
