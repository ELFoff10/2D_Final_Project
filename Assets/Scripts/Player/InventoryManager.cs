using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<WeaponController> WeaponSlots = new List<WeaponController>(6);
    public int[] WeaponLevels = new int[6];
    public List<Image> WeaponUiSlots = new List<Image>(6);
    public List<PassiveItem> PassiveItemSlots = new List<PassiveItem>(6);
    public int[] PassiveItemLevels = new int[6];
    public List<Image> PassiveItemUiSlots = new List<Image>(6);

    [Serializable]
    public class WeaponUpgrade
    {
        public GameObject InitialWeapon;
        public WeaponScriptableObject WeaponData;
    }
    
    [Serializable]
    public class PassiveItemUpgrade
    {
        public GameObject InitialPassiveItem;
        public PassiveItemScriptableObject PassiveItemData;
    }    
    
    [Serializable]
    public class UpgradeUI
    {
        public TMP_Text UpgradeNameDisplay;
        public TMP_Text UpgradeDescriptionDisplay;
        public Image UpgradeIcon;
        public Button UpgradeButton;
    }

    public List<WeaponUpgrade> WeaponUpgradeOptions = new List<WeaponUpgrade>();
    public List<PassiveItemUpgrade> PassiveItemUpgradeOptions = new List<PassiveItemUpgrade>();
    public List<UpgradeUI> UpgradeUIOptions = new List<UpgradeUI>();
    
    public void AddWeapon(int slotIndex, WeaponController weapon) 
    {
        WeaponSlots[slotIndex] = weapon;
        WeaponLevels[slotIndex] = weapon.WeaponData.Level;
        WeaponUiSlots[slotIndex].enabled = true;
        WeaponUiSlots[slotIndex].sprite = weapon.WeaponData.Icon;
    }

    public void AddPassiveItem(int slotIndex, PassiveItem passiveItem)
    {
        PassiveItemSlots[slotIndex] = passiveItem;
        PassiveItemLevels[slotIndex] = passiveItem.PassiveItemData.Level;
        PassiveItemUiSlots[slotIndex].enabled = true;
        PassiveItemUiSlots[slotIndex].sprite = passiveItem.PassiveItemData.Icon;
    }

    public void LevelUpWeapon(int slotIndex)
    {
        if (WeaponSlots.Count > slotIndex)
        {
            var weapon = WeaponSlots[slotIndex];
            if (!weapon.WeaponData.NextLevelPrefab)
            {
                return;
            }
            var upgradeWeapon = Instantiate(weapon.WeaponData.NextLevelPrefab, transform.position, Quaternion.identity);
            upgradeWeapon.transform.SetParent(transform);
            AddWeapon(slotIndex, upgradeWeapon.GetComponent<WeaponController>());
            Destroy(weapon.gameObject);
            WeaponLevels[slotIndex] = upgradeWeapon.GetComponent<WeaponController>().WeaponData.Level;
        }
    }

    public void LevelUpPassiveItem(int slotIndex)
    {
        if (PassiveItemSlots.Count > slotIndex)
        {
            var passiveItem = PassiveItemSlots[slotIndex];
            if (!passiveItem.PassiveItemData.NextLevelPrefab)
            {
                return;
            }
            var upgradePassiveItem = Instantiate(passiveItem.PassiveItemData.NextLevelPrefab, transform.position, Quaternion.identity);
            upgradePassiveItem.transform.SetParent(transform);
            AddPassiveItem(slotIndex, upgradePassiveItem.GetComponent<PassiveItem>());
            Destroy(passiveItem.gameObject);
            PassiveItemLevels[slotIndex] = upgradePassiveItem.GetComponent<PassiveItem>().PassiveItemData.Level;
        }
    }
}
