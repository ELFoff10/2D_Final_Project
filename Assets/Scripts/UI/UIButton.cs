using UnityEngine;

public class UIButton : MonoBehaviour
{
	public void Click()
	{
		AudioManager.Instance.PlayButtonClick();
	}
	
	public void MenuBackgroundMusicStart()
	{
		AudioManager.Instance.EventInstances[(int)AudioNameEnum.MenuBackgroundMusic].start();
	}
	
	public void MenuBackgroundMusicStop()
	{
		AudioManager.Instance.EventInstances[(int)AudioNameEnum.MenuBackgroundMusic].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}
	
	public void GameBackgroundMusicStart()
	{
		AudioManager.Instance.EventInstances[(int)AudioNameEnum.GameBackgroundMusic].start();
	}	
	
	public void GameBackgroundMusicLevel2Start()
	{
		AudioManager.Instance.EventInstances[(int)AudioNameEnum.GameBackgroundMusicLevel2].start();
	}	public void GameBackgroundMusicLevel2Stop()
	{
		AudioManager.Instance.EventInstances[(int)AudioNameEnum.GameBackgroundMusicLevel2].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}
	
	public void GameBackgroundMusicStop()
	{
		AudioManager.Instance.EventInstances[(int)AudioNameEnum.GameBackgroundMusic].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}
}