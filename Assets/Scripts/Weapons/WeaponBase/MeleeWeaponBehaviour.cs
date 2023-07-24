using UnityEngine;

/// <summary>
/// Base script of all melee behaviours [To be placed on a prefab of a weapon that is melee]
/// </summary>
public class MeleeWeaponBehaviour : MonoBehaviour
{
    [SerializeField] private WeaponScriptableObject _weaponData;
    [SerializeField] private float _destroyAfterSeconds;
    
    // Current stats
    protected float CurrentDamage;
    protected float CurrentSpeed;
    protected float CurrentCooldownDuration;
    protected int CurrentPierce;

    private void Awake()
    {
        CurrentDamage = _weaponData.Damage;
        CurrentSpeed = _weaponData.Speed;
        CurrentCooldownDuration = _weaponData.CooldownDuration;
        CurrentPierce = _weaponData.Pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, _destroyAfterSeconds);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyStats>();
            enemy.TakeDamage(GetCurrentDamage());
        }
        else if(other.CompareTag("Prop"))
        {
            if (other.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(GetCurrentDamage());
            }
        }
    }
    
    public float GetCurrentDamage()
    {
        return CurrentDamage *= FindObjectOfType<PlayerStats>().CurrentMight;
    }

}
