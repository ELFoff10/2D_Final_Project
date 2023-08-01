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
		CreateInstance(_fmodEvents.GameBackgroundMusic);
		CreateInstance(_fmodEvents.PauseBackgroundMusic);	
		CreateInstance(_fmodEvents.PickUpGem);
		CreateInstance(_fmodEvents.PickUpBottle);
		CreateInstance(_fmodEvents.DamageFlyBat);
	}

	public void PlayOneShot(EventReference sound)
	{
		RuntimeManager.PlayOneShot(sound);
	}

	public void PlayButtonClick()
	{
		PlayOneShot(_fmodEvents.ClickButton);
	}

	public void MenuBackgroundMusicStart()
	{
		EventInstances[(int)AudioNameEnum.MenuBackgroundMusic].start();
	}
	
	public void MenuBackgroundMusicStop()
	{
		EventInstances[(int)AudioNameEnum.MenuBackgroundMusic].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}
	
	public void GameBackgroundMusicStart()
	{
		EventInstances[(int)AudioNameEnum.GameBackgroundMusic].start();
	}
	
	public void GameBackgroundMusicStop()
	{
		EventInstances[(int)AudioNameEnum.GameBackgroundMusic].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}

	private EventInstance CreateInstance(EventReference eventReference)
	{
		var eventInstance = RuntimeManager.CreateInstance(eventReference);
		EventInstances.Add(eventInstance);
		return eventInstance;
	}
}