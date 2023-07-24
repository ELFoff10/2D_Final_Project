using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MeleeWeaponBehaviour
{
    private List<GameObject> _markedEnemies;
    protected override void Start()
    {
        base.Start();
        _markedEnemies = new List<GameObject>();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !_markedEnemies.Contains(other.gameObject))
        {
            var enemy = other.GetComponent<EnemyStats>();
            enemy.TakeDamage(GetCurrentDamage());
            
            _markedEnemies.Add(other.gameObject);
        }
        else if(other.CompareTag("Prop"))
        {
            if (!other.gameObject.TryGetComponent(out BreakableProps breakable) ||
                _markedEnemies.Contains(other.gameObject)) return;
            
            breakable.TakeDamage(GetCurrentDamage());
                
            _markedEnemies.Add(other.gameObject);
        }
    }
}
