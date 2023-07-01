using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    CharacterScriptableObject CharacterData;
    
    [HideInInspector]
    public float _currentHealth;
    [HideInInspector]
    public float _currentRecovery;
    [HideInInspector]
    public float _currentMoveSpeed;
    [HideInInspector]
    public float _currentMight;
    [HideInInspector]
    public float _currentProjectileSpeed;
    [HideInInspector]
    public float currentMagnet;
    
    //Swawned Weapon
    public List<GameObject> spawnedWeapons;

    // Experience and level of the player
    [Header("Experience/Level")]
    public int Experience = 0;

    public int Level = 1;
    public int ExperienceCap = 100;
    public int ExperienceCapIncrease;

    [Header("I-Frames")]
    public float invincibilityDuration;

    private float invincibilityTimer;
    private bool isInvincible;

    private void Awake()
    {
        CharacterData = CharacterSelector.GetData();
        CharacterSelector.Instance.DestroySingleton();
        
        // Assign the variables
        _currentHealth = CharacterData.MaxHealth;
        _currentRecovery = CharacterData.Recovery;
        _currentMoveSpeed = CharacterData.MoveSpeed;
        _currentMight = CharacterData.Might;
        _currentProjectileSpeed = CharacterData.ProjectileSpeed;
        currentMagnet = CharacterData.Magnet;
        
        // Spawn the starting weapon
        SpawnWeapon(CharacterData.StartingWeapon);
    }

    private void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        // If the invinvibility timer has reached 0, set the invincibility flag to false
        else if (isInvincible)
        {
            isInvincible = false;
        }
        
        Recover();
    }

    public void IncreaseExperience(int amount)
    {
        Experience += amount;

        LevelUpChecker();
    }

    void LevelUpChecker()
    {
        if (Experience >= ExperienceCap)
        {
            Level++;
            Experience -= ExperienceCap;
            ExperienceCap += ExperienceCapIncrease;
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            _currentHealth -= damage;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            if (_currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        Debug.Log("1");
    }

    public void RestoreHealth(float amount)
    {
        if (_currentHealth < CharacterData.MaxHealth)
        {
            _currentHealth += amount;

            if (_currentHealth > CharacterData.MaxHealth)
            {
                _currentHealth = CharacterData.MaxHealth;
            }
        }
    }

    void Recover()
    {
        if (_currentHealth < CharacterData.MaxHealth)
        {
            _currentHealth += _currentRecovery * Time.deltaTime;

            if (_currentHealth > CharacterData.MaxHealth)
            {
                _currentHealth = CharacterData.MaxHealth;
            }
        }
    }

    public void SpawnWeapon(GameObject weapon)
    {
        // Spawn the starting weapon
        var spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        spawnedWeapons.Add(spawnedWeapon);
    }
}