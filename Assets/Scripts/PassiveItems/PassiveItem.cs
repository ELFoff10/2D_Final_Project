using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    protected PlayerStats _playerStats;
    public PassiveItemScriptableObject PassiveItemData;

    protected virtual void ApplyModifier()
    {
        // Apply the boost value to the appropriate stat in the child classes
    }

    private void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
        ApplyModifier();
    }
}