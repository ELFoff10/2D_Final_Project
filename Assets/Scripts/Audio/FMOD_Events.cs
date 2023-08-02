using FMODUnity;
using UnityEngine;

public class FMOD_Events : MonoBehaviour
{
	[field: Header("UI")]
	[field: SerializeField]
	public EventReference ClickButton { get; private set; }
	[field: SerializeField]
	public EventReference MenuBackgroundMusic { get; private set; }
	
	[field: Header("Game Background Music")]
	[field: SerializeField]
	public EventReference GameBackgroundMusicLevel1 { get; private set; }	
	[field: SerializeField]
	public EventReference GameBackgroundMusicLevel2 { get; private set; }	
	
	[field: SerializeField]
	public EventReference PauseBackgroundMusic { get; private set; }
	
	[field: Header("Game")]
	[field: SerializeField]
	public EventReference PickUpGem { get; private set; }	
	[field: SerializeField]
	public EventReference PickUpBottle { get; private set; }
    [field: SerializeField]
	public EventReference DamageFlyBat { get; private set; }	 
	[field: SerializeField]
	public EventReference Victory { get; private set; }	
}