using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObject/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
	[SerializeField]
	private GameObject _prefab;
	public GameObject Prefab
	{
		get => _prefab;
		private set => _prefab = value;
	}
	[SerializeField]
	private float _damage;
	public float Damage
	{
		get => _damage;
		private set => _damage = value;
	}
	[SerializeField]
	private float _speed;
	public float Speed
	{
		get => _speed;
		private set => _speed = value;
	}
	[SerializeField]
	private float _cooldownDuration;
	public float CooldownDuration
	{
		get => _cooldownDuration;
		private set => _cooldownDuration = value;
	}
	[SerializeField]
	private int _pierce;
	public int Pierce
	{
		get => _pierce;
		private set => _pierce = value;
	}
	[SerializeField]
	private int _level;
	public int Level
	{
		get => _level;
		private set => _level = value;
	}
	[SerializeField]
	private GameObject _nextLevelPrefab;
	public GameObject NextLevelPrefab
	{
		get => _nextLevelPrefab;
		private set => _nextLevelPrefab = value;
	}
	[SerializeField]
	private string _name;
	public string Name
	{
		get => _name;
		private set => _name = value;
	}
	[SerializeField]
	private string _description;
	public string Description
	{
		get => _description;
		private set => _description = value;
	}
	[SerializeField]
	private Sprite _icon;
	public Sprite Icon
	{
		get => _icon;
		private set => _icon = value;
	}
}