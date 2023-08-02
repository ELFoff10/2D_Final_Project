using UnityEngine;

[CreateAssetMenu(fileName = "PassiveItemScriptableObject", menuName = "ScriptableObject/Passive Item")]
public class PassiveItemScriptableObject : ScriptableObject
{
	[SerializeField]
	private float _multiplier;

	public float Multiplier => _multiplier;

	[SerializeField]
	private int _level;
	public int Level => _level;

	[SerializeField]
	private GameObject _nextLevelPrefab;
	public GameObject NextLevelPrefab => _nextLevelPrefab;
	
	[SerializeField]
	private string _name;
	public string Name => _name;
	
	[SerializeField]
	private string _description;
	public string Description => _description;
	
	[SerializeField]
	private Sprite _icon;
	public Sprite Icon => _icon;
}