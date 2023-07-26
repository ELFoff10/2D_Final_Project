using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
	public enum GameState
	{
		Gameplay,
		Paused,
		GameOver,
		LevelUp
	}

	public GameState CurrentState;
	public GameState PreviousState;

	[Header("Screens")]
	public GameObject PauseScreen;
	public GameObject ResultsScreen;
	public GameObject LevelUpScreen;

	[Header("Current Stat Displays")]
	public TMP_Text CurrentHealthText;
	public TMP_Text CurrentRecoveryText;
	public TMP_Text CurrentMoveSpeedText;
	public TMP_Text CurrentMightText;
	public TMP_Text CurrentProjectileSpeedText;
	public TMP_Text CurrentMagnetText;

	[Header("Results Screen Displays")]
	public Image ChosenCharacterImage;
	public TMP_Text ChosenCharacterName;
	public TMP_Text LevelReachedDisplay;
	public TMP_Text TimeSurvivedDisplay;

	[Header("List")]
	public List<Image> ChosenWeaponsUI = new List<Image>(6);
	[Header("List")]
	public List<Image> ChosenPassiveItemsUI = new List<Image>(6);

	[Header("Stopwatch")]
	public float TimeLimit;
	private float _stopwatchTime;
	public TMP_Text StopwatchDisplay;

	public bool IsGameOver;

	public bool ChoosingUpgrade;

	public GameObject PlayerObject;

	private void Start()
	{
		DisableScreens();
	}

	private void Update()
	{
		switch (CurrentState)
		{
			case GameState.Gameplay:
				CheckForPauseAndResume();
				UpdateStopwatch();
				break;
			case GameState.Paused:
				CheckForPauseAndResume();
				break;
			case GameState.GameOver:
				if (!IsGameOver)
				{
					IsGameOver = true;
					Time.timeScale = 0f;
					DisplayResults();
				}

				break;
			case GameState.LevelUp:
				if (!ChoosingUpgrade)
				{
					ChoosingUpgrade = true;
					Time.timeScale = 0f;
					LevelUpScreen.SetActive(true);
				}

				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	public void ChangeState(GameState newState)
	{
		CurrentState = newState;
	}

	public void PauseGame()
	{
		if (CurrentState != GameState.Paused)
		{
			PreviousState = CurrentState;
			ChangeState(GameState.Paused);
			PauseScreen.SetActive(true);
			Time.timeScale = 0f;
		}
	}

	public void ResumeGame()
	{
		if (CurrentState == GameState.Paused)
		{
			ChangeState(PreviousState);
			PauseScreen.SetActive(false);
			Time.timeScale = 1f;
		}
	}

	private void CheckForPauseAndResume()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (CurrentState == GameState.Paused)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
		}
	}

	private void DisableScreens()
	{
		PauseScreen.SetActive(false);
		ResultsScreen.SetActive(false);
		LevelUpScreen.SetActive(false);
	}

	public void GameOver()
	{
		TimeSurvivedDisplay.text = StopwatchDisplay.text;
		ChangeState(GameState.GameOver);
	}

	private void DisplayResults()
	{
		ResultsScreen.SetActive(true);
	}

	public void AssignChosenCharacterUI(CharacterScriptableObject chosenCharacterData)
	{
		ChosenCharacterImage.sprite = chosenCharacterData.Icon;
		ChosenCharacterName.text = chosenCharacterData.Name;
	}

	public void AssignLevelReachedUI(int levelReachedData)
	{
		LevelReachedDisplay.text = levelReachedData.ToString();
	}

	public void AssignChosenWeaponsAndPassiveItemsUI(List<Image> chosenWeaponsData, List<Image> chosenPassiveItemsData)
	{
		if (chosenWeaponsData.Count != ChosenWeaponsUI.Count ||
		    chosenPassiveItemsData.Count != ChosenPassiveItemsUI.Count)
		{
			Debug.Log("Chosen weapons and passive items data lists have different lengths");
			return;
		}

		for (int i = 0; i < ChosenWeaponsUI.Count; i++)
		{
			if (chosenWeaponsData[i].sprite == true)
			{
				ChosenWeaponsUI[i].enabled = true;
				ChosenWeaponsUI[i].sprite = chosenWeaponsData[i].sprite;
			}
			else
			{
				ChosenWeaponsUI[i].enabled = false;
			}
		}

		for (int i = 0; i < ChosenPassiveItemsUI.Count; i++)
		{
			if (chosenPassiveItemsData[i].sprite == true)
			{
				ChosenPassiveItemsUI[i].enabled = true;
				ChosenPassiveItemsUI[i].sprite = chosenPassiveItemsData[i].sprite;
			}
			else
			{
				ChosenPassiveItemsUI[i].enabled = false;
			}
		}
	}

	private void UpdateStopwatch()
	{
		_stopwatchTime += Time.deltaTime;

		UpdatesStopwatchDisplay();

		if (_stopwatchTime >= TimeLimit)
		{
			PlayerObject.SendMessage("Kill");
		}
	}

	private void UpdatesStopwatchDisplay()
	{
		int minutes = Mathf.FloorToInt(_stopwatchTime / 60);
		int seconds = Mathf.FloorToInt(_stopwatchTime % 60);

		StopwatchDisplay.text = $"{minutes:00}:{seconds:00}";
	}

	public void StartLevelUp()
	{
		ChangeState(GameState.LevelUp);
		PlayerObject.SendMessage("RemoveAndApplyUpgrades");
	}

	public void EndLevelUp()
	{
		ChoosingUpgrade = false;
		Time.timeScale = 1f;
		LevelUpScreen.SetActive(false);
		ChangeState(GameState.Gameplay);
	}
}