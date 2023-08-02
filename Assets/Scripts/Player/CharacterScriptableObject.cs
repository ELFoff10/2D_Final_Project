using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObject/Character")]
public class CharacterScriptableObject : ScriptableObject
{   
    [SerializeField]
    private Sprite _icon;
    public Sprite Icon => _icon;
    
    [SerializeField]
    private string _name;
    public string Name => _name;
    
    [SerializeField]
    private GameObject _startingWeapon;
    public GameObject StartingWeapon => _startingWeapon;
    
    [SerializeField]
    private float _maxHealth;
    public float MaxHealth => _maxHealth;
    
    [SerializeField]
    private float _recovery;
    public float Recovery => _recovery;
    
    [SerializeField]
    private float _moveSpeed;
    public float MoveSpeed => _moveSpeed;

    [SerializeField]
    private float _might;
    public float Might => _might;

    [SerializeField]
    private float _projectileSpeed;
    public float ProjectileSpeed => _projectileSpeed;

    [SerializeField]
    private float _magnet;
    public float Magnet => _magnet;
}
