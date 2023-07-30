public class UpHealthPassiveItem : PassiveItem
{
	protected override void ApplyModifier()
	{
		PlayerStats.CurrentHealth *= 1 + PassiveItemData.Multiplier / 100f;
	}
}