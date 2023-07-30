using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	public CharacterScriptableObject CharacterData;

	private float _currentRegenHp;
	private float _currentHealth;
	private float _currentMoveSpeed;
	private float _currentMight;
	private float _currentProjectileSpeed;
	private float _currentMagnet;

	#region Current Stats Properties

	public float CurrentHealth
	{
		get => _currentHealth;
		set
		{
			if (_currentHealth != value)
			{
				_currentHealth = value;
				if (GameManager.Instance != null)
				{
					GameManager.Instance.CurrentHealthText.text = "Health: " + _currentHealth;
				}
			}
		}
	}

	public float CurrentRegenHp
	{
		get => _currentRegenHp;
		set
		{
			if (_currentRegenHp != value)
			{
				_currentRegenHp = value;
				if (GameManager.Instance != null)
				{
					GameManager.Instance.CurrentRecoveryText.text = "RegenHp: " + _currentRegenHp;
				}
			}
		}
	}

	public float CurrentMoveSpeed
	{
		get => _currentMoveSpeed;
		set
		{
			if (_currentMoveSpeed != value)
			{
				_currentMoveSpeed = value;
				if (GameManager.Instance != null)
				{
					GameManager.Instance.CurrentMoveSpeedText.text = "Move Speed:" + _currentMoveSpeed;
				}
			}
		}
	}

	public float CurrentMight
	{
		get => _currentMight;
		set
		{
			if (_currentMight != value)
			{
				_currentMight = value;
				if (GameManager.Instance != null)
				{
					GameManager.Instance.CurrentMightText.text = "Might:" + _currentMight;
				}
			}
		}
	}

	public float CurrentProjectileSpeed
	{
		get => _currentProjectileSpeed;
		set
		{
			if (_currentProjectileSpeed != value)
			{
				_currentProjectileSpeed = value;
				if (GameManager.Instance != null)
				{
					GameManager.Instance.CurrentProjectileSpeedText.text =
						"Projectile Speed:" + _currentProjectileSpeed;
				}
			}
		}
	}

	public float CurrentMagnet
	{
		get => _currentMagnet;
		set
		{
			if (_currentMagnet != value)
			{
				_currentMagnet = value;
				if (GameManager.Instance != null)
				{
					GameManager.Instance.CurrentMagnetText.text = "Magnet:" + _currentMagnet;
				}
			}
		}
	}

	#endregion

	[HideInInspector]
	public Animator _currentAnimator;

	[Header("Experience/Level")]
	public int Experience = 0;
	public int Level = 1;
	public int ExperienceCap = 100;
	public int ExperienceCapIncrease;

	[Header("I-Frames")]
	public float InvincibilityDuration;

	private float _invincibilityTimer;
	private bool _isInvincible;

	private InventoryManager _inventory;
	public int WeaponIndex;
	public int PassiveItemIndex;

	[Header("UI")]
	public Image HealthBar;
	public Image ExperienceBar;
	public TMP_Text LevelText;


	private void Awake()
	{
		if (CharacterSelector.Instance != null)
		{
			CharacterData = CharacterSelector.Instance.GetData();
			CharacterSelector.Instance.DestroyCharacterSelector();
		}

		_inventory = GetComponent<InventoryManager>();
		_currentAnimator = GetComponent<Animator>();

		CurrentHealth = CharacterData.MaxHealth;
		CurrentRegenHp = CharacterData.Recovery;
		CurrentMoveSpeed = CharacterData.MoveSpeed;
		CurrentMight = CharacterData.Might;
		CurrentProjectileSpeed = CharacterData.ProjectileSpeed;
		CurrentMagnet = CharacterData.Magnet;

		SpawnWeapon(CharacterData.StartingWeapon);
	}

	private void Start()
	{
		GameManager.Instance.CurrentHealthText.text = "Health:" + _currentHealth;
		GameManager.Instance.CurrentRecoveryText.text = "Recovery: " + _currentRegenHp;
		GameManager.Instance.CurrentMoveSpeedText.text = "Move Speed: " + _currentMoveSpeed;
		GameManager.Instance.CurrentMightText.text = "Might: " + _currentMight;
		GameManager.Instance.CurrentProjectileSpeedText.text = "Projectile Speed: " + _currentProjectileSpeed;
		GameManager.Instance.CurrentMagnetText.text = "Magnet: " + _currentMagnet;

		GameManager.Instance.AssignChosenCharacterUI(CharacterData);

		UpdateHealthBar();
		UpdateExperienceBar();
		UpdateLevelText();
	}

	private void Update()
	{
		if (_invincibilityTimer > 0)
		{
			_invincibilityTimer -= Time.deltaTime;
		}

		else if (_isInvincible)
		{
			_isInvincible = false;
		}

		Recover();
	}

	public void IncreaseExperience(int amount)
	{
		Experience += amount;

		LevelUpChecker();

		UpdateExperienceBar();
	}

	void LevelUpChecker()
	{
		if (Experience < ExperienceCap) return;
		Level++;
		Experience -= ExperienceCap;
		ExperienceCap += ExperienceCapIncrease;

		UpdateLevelText();

		GameManager.Instance.StartLevelUp();
	}

	private void UpdateExperienceBar()
	{
		ExperienceBar.fillAmount = (float)Experience / ExperienceCap;
	}

	private void UpdateLevelText()
	{
		LevelText.text = "LEVEL: " + Level.ToString();
	}

	public void TakeDamage(float damage)
	{
		if (_isInvincible) return;

		CurrentHealth -= damage;

		_invincibilityTimer = InvincibilityDuration;
		_isInvincible = true;

		if (CurrentHealth <= 0)
		{
			Kill();
		}

		UpdateHealthBar();
	}

	private void UpdateHealthBar()
	{
		HealthBar.fillAmount = CurrentHealth / CharacterData.MaxHealth;
	}

	private void Kill()
	{
		if (GameManager.Instance.IsGameOver)
			return;
		GameManager.Instance.AssignLevelReachedUI(Level);
		GameManager.Instance.AssignChosenWeaponsAndPassiveItemsUI(_inventory.WeaponUiSlots,
			_inventory.PassiveItemUiSlots);
		GameManager.Instance.GameOver();
	}

	public void RestoreHealth(float amount)
	{
		if (CurrentHealth < CharacterData.MaxHealth)
		{
			CurrentHealth += amount;

			if (CurrentHealth > CharacterData.MaxHealth)
			{
				CurrentHealth = CharacterData.MaxHealth;
			}
		}
	}

	public void ReduceHealth(float amount)
	{
		CurrentHealth -= amount;

		if (CurrentHealth < 0)
		{
			Kill();
		}
	}

	private void Recover()
	{
		if (CurrentHealth < CharacterData.MaxHealth)
		{
			CurrentHealth += CurrentRegenHp * Time.deltaTime;

			if (CurrentHealth > CharacterData.MaxHealth)
			{
				CurrentHealth = CharacterData.MaxHealth;
			}
		}
	}

	public void SpawnWeapon(GameObject weapon)
	{
		if (WeaponIndex >= _inventory.WeaponSlots.Count - 1)
		{
			return;
		}

		var spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
		spawnedWeapon.transform.SetParent(transform);
		_inventory.AddWeapon(WeaponIndex, spawnedWeapon.GetComponent<WeaponController>());
		WeaponIndex++;
	}

	public void SpawnPassiveItem(GameObject passiveItem)
	{
		if (PassiveItemIndex >= _inventory.PassiveItemSlots.Count - 1)
		{
			return;
		}

		var spawnPassiveItem = Instantiate(passiveItem, transform.position, Quaternion.identity);
		spawnPassiveItem.transform.SetParent(transform);
		_inventory.AddPassiveItem(PassiveItemIndex, spawnPassiveItem.GetComponent<PassiveItem>());
		PassiveItemIndex++;
	}
}