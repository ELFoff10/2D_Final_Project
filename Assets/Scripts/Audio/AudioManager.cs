using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
	[SerializeField]
	private FMOD_Events _fmodEvents;

	public List<EventInstance> EventInstances;

	protected override void Awake()
	{
		base.Awake();
		EventInstances = new List<EventInstance>();
		CreateInstance(_fmodEvents.ClickButton);
		CreateInstance(_fmodEvents.MenuBackgroundMusic);
		CreateInstance(_fmodEvents.GameBackgroundMusicLevel1);
		CreateInstance(_fmodEvents.PauseBackgroundMusic);	
		CreateInstance(_fmodEvents.PickUpGem);
		CreateInstance(_fmodEvents.PickUpBottle);
		CreateInstance(_fmodEvents.DamageFlyBat);
		CreateInstance(_fmodEvents.GameBackgroundMusicLevel2);
		CreateInstance(_fmodEvents.Victory);
		
	}

	public void PlayOneShot(EventReference sound)
	{
		RuntimeManager.PlayOneShot(sound);
	}

	public void PlayButtonClick()
	{
		PlayOneShot(_fmodEvents.ClickButton);
	}

	private EventInstance CreateInstance(EventReference eventReference)
	{
		var eventInstance = RuntimeManager.CreateInstance(eventReference);
		EventInstances.Add(eventInstance);
		return eventInstance;
	}
}