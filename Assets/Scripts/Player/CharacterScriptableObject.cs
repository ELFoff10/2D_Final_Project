using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObject/Character")]
public class CharacterScriptableObject : ScriptableObject
{   
    [SerializeField]
    private Sprite _icon;
    public Sprite Icon { get => _icon; private set => _icon = value; }   
    [SerializeField]
    private string _name;
    public string Name { get => _name; private set => _name = value; }
    [SerializeField]
    private GameObject _startingWeapon;
    public GameObject StartingWeapon { get => _startingWeapon; private set => _startingWeapon = value; }   
    [SerializeField]
    private float _maxHealth;
    public float MaxHealth { get => _maxHealth; private set => _maxHealth = value; }    
    [SerializeField]
    private float _recovery;
    public float Recovery { get => _recovery; private set => _recovery = value; }    
    [SerializeField]
    private float _moveSpeed;
    public float MoveSpeed { get => _moveSpeed; private set => _moveSpeed = value; }   
    [SerializeField]
    private float _might;
    public float Might { get => _might; private set => _might = value; }   
    [SerializeField]
    private float _projectileSpeed;
    public float ProjectileSpeed { get => _projectileSpeed; private set => _projectileSpeed = value; }
    [SerializeField]
    private float _magnet;
    public float Magnet { get => _magnet; private set => _magnet = value; }
    [SerializeField]
    private AnimatorController _animator;
    public AnimatorController Animator { get => _animator; private set => _animator = value; }
}
