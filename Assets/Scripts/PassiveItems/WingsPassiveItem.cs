public class WingsPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        _playerStats.CurrentMoveSpeed *= 1 + PassiveItemData.Multiplier / 100f;
    }
}
