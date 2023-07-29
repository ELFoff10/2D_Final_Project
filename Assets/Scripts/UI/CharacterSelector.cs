using System;

public class CharacterSelector : MonoSingleton<CharacterSelector>
{
	private CharacterScriptableObject _characterData;

	protected override void Awake()
	{
		base.Awake();
	}

	private void Start()
	{
		AudioManager.Instance.EventInstances[1].start();
	}

	public CharacterScriptableObject GetData()
	{
		return _characterData;
	}

	public void SelectCharacter(CharacterScriptableObject character)
	{
		_characterData = character;
	}

	public void DestroyCharacterSelector()
	{
		Instance = null;
		Destroy(gameObject);
	}
}