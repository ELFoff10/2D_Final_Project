using UnityEngine;

public class ArrowBehaviour : ProjectileWeaponBehaviour
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        transform.position += direction * currentSpeed * Time.deltaTime; 
    }
}
