public class UpProjectileSpeedPassiveItem : PassiveItem
{
	protected override void ApplyModifier()
	{
		PlayerStats.CurrentProjectileSpeed *= 1 + PassiveItemData.Multiplier / 100f;
	}
}