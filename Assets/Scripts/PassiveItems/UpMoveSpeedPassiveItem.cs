public class UpMoveSpeedPassiveItem : PassiveItem
{
	protected override void ApplyModifier()
	{
		PlayerStats.CurrentMoveSpeed *= 1 + PassiveItemData.Multiplier / 100f;
	}
}