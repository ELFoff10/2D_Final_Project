public class UpMagnetPassiveItem : PassiveItem
{
	protected override void ApplyModifier()
	{
		PlayerStats.CurrentMagnet *= 1 + PassiveItemData.Multiplier / 100f;
	}
}