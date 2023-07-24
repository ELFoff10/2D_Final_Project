public class SpinachPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        _playerStats.CurrentMight *= 1 + PassiveItemData.Multiplier / 100f;
    }
}