using FMOD.Studio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public void SceneChange(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
		Time.timeScale = 1f;
	}

	public void Restart()
	{
		GameManager.Instance.CurrentState = GameManager.GameState.Gameplay;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1f;
	}

	public void Menu(string sceneName)
	{
		AudioManager.Instance.EventInstances[(int)AudioNameEnum.PauseBackgroundMusic].stop(STOP_MODE.ALLOWFADEOUT);
		AudioManager.Instance.EventInstances[(int)AudioNameEnum.GameBackgroundMusic].stop(STOP_MODE.ALLOWFADEOUT);
		SceneManager.LoadScene(sceneName);
	}

	public void Quit()
	{
		Application.Quit();
	}
}