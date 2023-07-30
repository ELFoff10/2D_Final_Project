public class UpRegenHpPassiveItem : PassiveItem
{
	protected override void ApplyModifier()
	{
		PlayerStats.CurrentRegenHp *= 1 + PassiveItemData.Multiplier / 100f;
	}
}