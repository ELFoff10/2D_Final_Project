using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObject/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField] 
    private GameObject _prefab;
    public GameObject Prefab { get => _prefab; private set => _prefab = value; }
    // Base stats for weapons
    [SerializeField] 
    private float _damage;
    public float Damage { get => _damage; private set => _damage = value; }
    [SerializeField] 
    private float _speed;
    public float Speed { get => _speed; private set => _speed = value; }
    [SerializeField] 
    private float _cooldownDuration;
    public float CooldownDuration { get => _cooldownDuration; private set => _cooldownDuration = value; }
    [SerializeField] 
    private int _pierce;
    public int Pierce { get => _pierce; private set => _pierce = value; }
}
