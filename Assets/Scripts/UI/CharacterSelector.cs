public class CharacterSelector : MonoSingleton<CharacterSelector>
{
	private CharacterScriptableObject _characterData;

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