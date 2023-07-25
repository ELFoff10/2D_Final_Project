using UnityEngine;

[CreateAssetMenu(fileName = "PassiveItemScriptableObject", menuName = "ScriptableObject/Passive Item")]
public class PassiveItemScriptableObject : ScriptableObject
{
    [SerializeField]
    private float _multiplier;

    public float Multiplier
    {
        get => _multiplier;
        private set => _multiplier = value;
    }
    
    [SerializeField] 
    private int _level; // Not meant to be modified in the game [Only in Editor]
    public int Level { get => _level; private set => _level = value; }    
    
    [SerializeField] 
    private GameObject _nextLevelPrefab;
    public GameObject NextLevelPrefab { get => _nextLevelPrefab; private set => _nextLevelPrefab = value; }
    [SerializeField] 
    private string _name;
    public string Name { get => _name; private set => _name = value; }   
    [SerializeField] 
    private string _description;
    public string Description { get => _description; private set => _description = value; }
    [SerializeField] 
    private Sprite _icon;
    public Sprite Icon { get => _icon; private set => _icon = value; }
}